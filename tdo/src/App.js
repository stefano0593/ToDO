import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import { SignUp } from './authentication/singup/signup';
import { SigIn } from './authentication/signin/signin';

function App() {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<SignUp />} />
                <Route path="/sigin" element={<SigIn />} />
            </Routes>
        </Router>
    );
}

export default App;
