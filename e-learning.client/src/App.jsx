import React from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import RegistrationForm from "./componets/RegistrationForm"; //     path 
import LogIn from "./componets/Login";
import Homepage from "./componets/Homepage";
import Student from "./componets/Student";

import 'bootstrap/dist/css/bootstrap.min.css';



const App = () => {
  return (
    
    <Router>
      <Routes>
        <Route path='/' element={<RegistrationForm></RegistrationForm>}></Route>
        <Route path='/SignIn' element={<LogIn></LogIn>}></Route>
        <Route path='/Login' element={<LogIn></LogIn>}></Route>
        <Route path='/Homepage' element={<Homepage></Homepage>}></Route>
        <Route path='/Student' element={<Student></Student>}></Route>

      </Routes>
    </Router>
  
);
};


export default App;

