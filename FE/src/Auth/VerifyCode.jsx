import React, { Fragment, useState } from 'react';
import { Button, Col, Container, Form, FormGroup, Input, Label, Row } from 'reactstrap';
import { Btn, H4, P, Image } from '../AbstractElements';
import { Link, useParams } from 'react-router-dom';
import authApi from '../api/auth/authApi';
import logoWhite from '../assets/images/logo/logo.png';
import logoDark from '../assets/images/logo/logo_dark.png';

const VerifyCode = () => {
    const [verifyCode, setVerifyCode] = useState("");
    const [togglePassword, setTogglePassword] = useState(false);
    const [verifying, setVerifying] = useState(false);
    const { userId } = useParams();
    const onVerify = () => {
        setVerifying(true);
        authApi.verifyCode(userId, verifyCode).then(response => {
            if (response.accessToken) {
                sessionStorage.setItem('token', response.accessToken.token);
                setVerifying(false);
                window.location.href = `${process.env.PUBLIC_URL}/`;
            }
        }).catch(err => {
            console.log(err);
        })
    }

    return (
        <Fragment>
            <section>
                <Container fluid={true} className='p-0 login-page'>
                    <Row className='m-0'>
                        <Col className='p-0'>
                            <div className='login-card'>
                                <div>
                                    <div>
                                        <Link className={`logo`} to={process.env.PUBLIC_URL}>
                                            <Image attrImage={{ className: 'img-fluid for-light', src: logoWhite, alt: 'looginpage' }} />
                                            <Image attrImage={{ className: 'img-fluid for-dark', src: logoDark, alt: 'looginpage' }} />
                                        </Link>
                                    </div>
                                    <div className='login-main unlock-user'>
                                        <Form className='theme-form login-form'>
                                            <H4>Verify Code</H4>
                                            <FormGroup className='position-relative'>
                                                <Label className='col-form-label'>Enter your Verify Code</Label>
                                                <div className='position-relative'>
                                                    <Input className='form-control' type='text' name='verifyCode' required onChange={(e) => setVerifyCode(e.target.value)} />
                                                </div>
                                            </FormGroup>
                                            <FormGroup>
                                                <Button color='primary' onClick={() => onVerify()} active={verifying ? false : true}>{verifying ? "Verifying...." : "Verify Code"}</Button>
                                            </FormGroup>
                                        </Form>
                                    </div>
                                </div>
                            </div>
                        </Col>
                    </Row>
                </Container>
            </section>
        </Fragment>
    );
}

export default VerifyCode;