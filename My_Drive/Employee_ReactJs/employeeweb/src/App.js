import './App.css';
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Navbar from "./components/Navbar";
import Home from './components/Home';
import Employee from './components/Employee';

function App() {
  return (
    <Router>
      <Navbar />
      <Routes>
        <Route exact path="/" element={<Home/>} />
        <Route path="/employee/:id" element={<Employee/>} />
        <Route path="/employee" element={<Employee/>} />
      </Routes>
    </Router>
  );
}

export default App;
