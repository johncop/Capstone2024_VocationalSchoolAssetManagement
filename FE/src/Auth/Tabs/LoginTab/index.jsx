import React, { Fragment, useState, useEffect, useContext } from 'react';
import { Button, Form, FormGroup, Input, Label } from 'reactstrap';
import { Btn, H4, P } from '../../../AbstractElements';
import { EmailAddress, ForgotPassword, LoginWithJWT, Password, RememberPassword, SignIn } from '../../../Constant';

import { toast } from 'react-toastify';
import authApi from '../../../api/auth/authApi';

const LoginTab = ({ selected }) => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [togglePassword, setTogglePassword] = useState(false);
  const [logging, setLogging] = useState(false);

  const loginWithJwt = (e) => {
    if (email === '' && password === '') {
      return toast.error("Input your email and password");
    }

    setLogging(true);
    authApi.login(email, password).then(response => {
      if (response.userId) {
        setLogging(false);
        window.location.href = `${process.env.PUBLIC_URL}/verify/${response.userId}`;
      }
    });
  };

  return (
    <Fragment>
      <Form className='theme-form' onSubmit={(e) => loginWithJwt(e)}>
        <H4>Sign In</H4>
        <P>{'Enter your email & password to login'}</P>
        <FormGroup>
          <Label className='col-form-label'>{EmailAddress}</Label>
          <Input className='form-control' type='email' onChange={(e) => setEmail(e.target.value)} value={email} readOnly={logging ? true : false} />
        </FormGroup>
        <FormGroup className='position-relative'>
          <Label className='col-form-label'>{Password}</Label>
          <div className='position-relative'>
            <Input className='form-control' type={togglePassword ? 'text' : 'password'} onChange={(e) => setPassword(e.target.value)} value={password} readOnly={logging ? true : false} />
          </div>
        </FormGroup>
        <div className='position-relative form-group mb-0'>
          <div className='checkbox'>
            <Input id='checkbox1' type='checkbox' />
            <Label className='text-muted' for='checkbox1'>
              {RememberPassword}
            </Label>
          </div>
          <a className='link' href='#javascript'>
            {ForgotPassword}
          </a>
          <Button color='primary' active={logging ? true : false} onClick={(e) => loginWithJwt(e)} className='d-block w-100 mt-2'>{logging ? "Signing....." : "Sign In"}</Button>
        </div>
      </Form>
    </Fragment>
  );
};

export default LoginTab;
