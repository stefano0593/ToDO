import { TextField } from '@mui/material';
import { Button } from '@mui/material';
import Logo from '../../assets/logo.png';
import './signin.css';
import { useState } from 'react';

export const SigIn = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const getEmail = (event) => {
        setEmail(event.target.value);
    };
    const getPassword = (event) => {
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
