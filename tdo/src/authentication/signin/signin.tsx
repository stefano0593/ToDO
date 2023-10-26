import { TextField } from '@mui/material';
import { Button } from '@mui/material';
import './signin.css';
import { useState } from 'react';
import React from 'react';

const Logo = require('../../assets/logo.png');

export const SigIn = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const getEmail = (event: any) => {
        setEmail(event.target.value);
    };
    const getPassword = (event: any) => {
        setPassword(event.target.value);
    };

    const Submit = () => {
        console.log(email, password);
    };

    return (
        <div className="sigin-container">
            <div className="logo-title">
                <img alt="Logo" className="logo" src={Logo}></img>
                <h1 className="title-text">Todo</h1>
            </div>
            <div className="form">
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
                    Sign In
                </Button>
            </div>
        </div>
    );
};
