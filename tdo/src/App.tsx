import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import { SignUp } from './authentication/singup/signup';
import { SigIn } from './authentication/signin/signin';
import { Layout } from './global/layout/layout';
import React from 'react';

function App() {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<SignUp />} />
                <Route path="/signin" element={<SigIn />} />
                <Route path="/layout" element={<Layout />} />
            </Routes>
        </Router>
    );
}

export default App;
