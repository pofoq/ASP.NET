import Home from './components/Home';
import JokePage from './components/JokePage';
import ErrorPage from './components/ErrorPage';
import NotFoundPage from './components/NotFoundPage'
import './App.css';
import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom'
import Counter from './components/counter';

function App() {
  return (
    <div>
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
            <li>
              <Link to='/counter'>Counter</Link>
            </li>
          </ul>
        </nav>

        <Routes>
          <Route path='/' element={<Home />} />
          <Route path='/joke' element={<JokePage />} />
          <Route path='/error' element={<ErrorPage />} />
          <Route path='/counter' element={<Counter />} />
          <Route path='*' element={<NotFoundPage />} />
        </Routes>
      </Router>
    </div>
  );
}

export default App;
