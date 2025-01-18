import Home from './components/Home';
import JokePage from './components/JokePage';
import ErrorPage from './components/ErrorPage';
import './App.css';
import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom'

function App() {
  return (
    <Router>
      <nav className='navbar'>
        <ul className='navbar-links'>
          <li>
            <Link to='/'>Home</Link>
          </li>
          <li>
            <Link to='/joke'>Joke</Link>
          </li>
          <li>
            <Link to='/error'>Error</Link>
          </li>
        </ul>
      </nav>

      <Routes>
        <Route path='/' element={<Home />} />
        <Route path='/joke' element={<JokePage />} />
        <Route path='/error' element={<ErrorPage />} />
      </Routes>
    </Router>
  );
}

export default App;
