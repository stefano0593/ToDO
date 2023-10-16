import { TextField } from '@mui/material';
import { Button } from '@mui/material';
import Logo from '../assets/logo.png';
import './signup.css';
export const SignUp = () => {
    return (
        <div className="signup-container">
            <div className="logo-title">
                <img alt="Logo" className="logo" src={Logo}></img>
                <h1 className="title-text">Todo</h1>
            </div>
            <div className="form">
                <TextField label="First Name" variant="outlined" />
                <TextField label="Last Name" variant="outlined" />
                <TextField label="Email" variant="outlined" />
                <TextField label="Password" variant="outlined" />
                <Button variant="contained">Sign Up</Button>
            </div>
        </div>
    );
};
