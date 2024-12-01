import React from 'react';
import { Nav, NavItem, NavLink } from 'reactstrap';
import { AUTH0, JWT } from '../Constant';
import { Image } from '../AbstractElements';
import simpleLogin from '../assets/images/simple-login.svg';
import jwtImg from '../assets/images/jwt.svg';
import authImg from '../assets/images/auth0.svg';

const NavAuth = ({ callbackNav, selected }) => {
  return (
    <Nav className='border-tab flex-column' tabs>
      <NavItem>
        <NavLink className="active">
          <Image attrImage={{ src: `${jwtImg}`, alt: '' }} />
          <span>{JWT}</span>
        </NavLink>
      </NavItem>
    </Nav>
  );
};

export default NavAuth;
