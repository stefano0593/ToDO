import { TextField } from '@mui/material';
import { Button } from '@mui/material';
import './signup.css';
import { useState } from 'react';
import React from 'react';
import { SignInRequest } from '../data/types';

const Logo = require('../../assets/logo.png');

export const SignUp = () => {
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const getFirstName = (event: any) => {
        setFirstName(event.target.value);
    };
    const getLastName = (event: any) => {
        setLastName(event.target.value);
    };
    const getEmail = (event: any) => {
        setEmail(event.target.value);
    };
    const getPassword = (event: any) => {
        setPassword(event.target.value);
    };
    const Submit = () => {
        const person: SignInRequest = {
            firstName: firstName,
            lastName: lastName,
            email: email,
            password: password,
        };
        const headers = {
            'Content-Type': 'application/json',
        };
        const urlApi = 'http://localhost:5113/api/Accounts';
        fetch(urlApi, {
            method: 'POST',
            body: JSON.stringify(person),
            headers: headers,
        }).then((response) => console.log(response));
    };

    return (
        <div className="signup-container">
            <div className="logo-title">
                <img alt="Logo" className="logo" src={Logo}></img>
                <h1 className="title-text">Todo</h1>
            </div>
            <div className="form">
                <TextField
                    type="text"
                    label="First Name"
                    variant="outlined"
                    onChange={getFirstName}
                />
                <TextField
                    type="text"
                    label="Last Name"
                    variant="outlined"
                    onChange={getLastName}
                />
                <TextField
                    type="email"
                    label="Email"
                    variant="outlined"
                    onChange={getEmail}
                />
                <TextField
                    type="password"
                    label="Password"
                    variant="outlined"
                    onChange={getPassword}
                />
                <Button variant="contained" onClick={Submit}>
                    Sign Up
                </Button>
            </div>
        </div>
    );
};
