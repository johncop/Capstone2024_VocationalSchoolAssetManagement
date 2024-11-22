import React, { useEffect, useState } from 'react';
import Context from './index';
import ChatBot from "react-chatbotify";

const ChatBotProvider = (props) => {

  const helpOptions = ["My request", "New Request", "Expired Request", "Free Chat", "No Thanks"];
  const [form, setForm] = React.useState({});
	const formStyle = {
		marginTop: 10,
		marginLeft: 20,
		border: "1px solid #491d8d",
		padding: 10,
		borderRadius: 5,
		maxWidth: 300
	}

  let apiKey = null;
	let modelType = "gpt-3.5-turbo";
	let hasError = false;

  //Call Chat GPT api
  const call_openai = async (params) => {
		// try {
		// 	const openai = new OpenAI({
		// 		apiKey: apiKey,
		// 		dangerouslyAllowBrowser: true // required for testing on browser side, not recommended
		// 	});

		// 	// for streaming responses in parts (real-time), refer to real-time stream example
		// 	const chatCompletion = await openai.chat.completions.create({
		// 		// conversation history is not shown in this example as message length is kept to 1
		// 		messages: [{ role: 'user', content: params.userInput }],
		// 		model: modelType,
		// 	});

		// 	await params.injectMessage(chatCompletion.choices[0].message.content);
		// } catch (error) {
		// 	await params.injectMessage("Unable to load model, is your API Key valid?");
		// 	hasError = true;
		// }
	}

  // Call API Asset management
  async function fetchData(params) {
		try {
			const response = await fetch('https://assetmanagement-dmd5bng3bcffdpab.southeastasia-01.azurewebsites.net/api/asset', {
        method: "GET",
        headers: {
          "Accept": "application/json"
        }
      })
			const data = await response.json(); 
			return data;
		} catch (error) {
      console.log(error);
			return "Oh no I don't know what to say!";
		}
	}

  const flow={
		start: {
			message: "Hi! I am Botify!",
			path: "show_options"
		},
    show_options: {
			message: "Can i help you Sir!",
			options: helpOptions,
			path: "process_options"
		},
    prompt_again: {
			message: "Do you need any other help?",
			options: helpOptions,
			path: "process_options"
		},
    process_options: {
			transition: {duration: 0},
			chatDisabled: true,
			path: async (params) => {
				switch (params.userInput) {
				case "My request":
					return "requested_assets";

				case "New Request":
					return "asset_type_choices";

				case "Expired Request":
					
					break;
				case "Free Chat":
					return "free_chat";
      
        case "No Thanks":				
					return "end";

				default:
					return "end";
				}
			},
		},
    end: {
			message: "Talk to me anytime, Goodbye !",
      chatDisabled: true,
			path: "start"
		},
    free_chat: {
			message: "Hello there! Now you can ask me something you like !",
			path: "loop_free_chat"
		},
    loop_free_chat: {
			message: async (params) => {
				await call_openai(params);
			},
			path: () => {
				if (hasError) {
					return "end"
				}
				return "loop_free_chat"
			}
    },
		requested_assets: {
			message: async (params) => {
				const result = await fetchData(params);
				return "I found some request that you have requested !";
			},
      checkboxes: {items: ["Dog", "Cat", "Rabbit", "Hamster", "Bird"], min: 2, max: 4},
			path: "prompt_again",
		},
    asset_type_choices: {
			message: "What type of asset you want ?",
      checkboxes: {items: ["PC", "Laptop", "Monitor", "Keyboard", "Mouse"], min: 2, max: 4},
      function: (params) => setForm({...form, asset_type_choices: params.userInput}),
			path: "asset_condition_choices",
		},
    asset_condition_choices: {
			message: "What condition of asset you want ?",
      checkboxes: {items: ["New", "Second-hand"], min: 1, max: 1},
      function: (params) => setForm({...form, asset_condition_choices: params.userInput}),
			path: "asset_quantity_choices",
		},
    asset_quantity_choices: {
			message: "How many  asset you want ?",
      function: (params) => setForm({...form, asset_quantity_choices: params.userInput}),
			path: "asset_condition_choices",
		},
    asset_quantity_choices: {
			message: "How many  asset you want ?",
      function: (params) => setForm({...form, asset_quantity_choices: params.userInput}),
			path: "request_date_expired_choices",
		},
    request_date_expired_choices: {
			message: "What date you want to loan to?",
      function: (params) => setForm({...form, asset_expired_date_choices: params.userInput}),
			path: "get_assets",
		},
    get_assets: {
			message: async (params) => {
				//const result = await fetchData(params);
				return "I found some request that you have requested !";
			},
      checkboxes: {items: ["Asset 1", "Asset 2", "Asset 3"], min: 1, max: 1},
      function: (params) => setForm({...form, asset_choices: params.userInput}),
			path: "request_assets",
		},
    request_assets: {
			message: "This is your asset you want ?",
			component: (
				<div style={formStyle}>
					<p>Name: {form.asset_choices}</p>
					<p>Condition: {form.asset_condition_choices}</p>
					<p>Asset Type: {form.asset_type_choices}</p>
					<p>Quantity: {form.asset_quantity_choices}</p>
					<p>Expired At: {form.asset_expired_date_choices}</p>
				</div>
			),
			path: "make_request_assets",
		},
    make_request_assets: {
			message: "Make a new asset request with information above ?",
      options: ["Confirm", "Cancel"],
			path: "confirm_options"
		},
    confirm_options: {
			transition: {duration: 0},
			chatDisabled: true,
			path: async (params) => {
				switch (params.userInput) {
				case "Confirm":
					return "requested_assets";

				case "Cancel":
					return "prompt_again";

				default:
					return "end";
				}
			},
		},
    post_new_asset: {
			message: async (params) => {
				//const result = await fetchData(params);
				return "I have requested a new loan reaquest!";
			},
			path: "end",
		}
	}

  return (
    <Context.Provider value={{...props}}>
      <ChatBot flow={flow}/>
      {props.children}
    </Context.Provider>
  );
};

export default ChatBotProvider;
