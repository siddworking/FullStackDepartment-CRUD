import logo from './logo.svg';
import './App.css';
import { BrowserRouter as Router ,Route, Switch } from 'react-router-dom';
import DepartmentList from './Components/DepartmentsList';
import DepartmentAdd from './Components/DepartmentAdd';
import Login from './Components/Login';
import {  useState } from 'react';
import DepartmentUpdate from './Components/DepartmentUpdate';
import Loginverify from './Components/Loginverify';

function App() {

  // const [deptarr , setdeptarr] = useState([]);
  // const update =(dept)=>{
  //     setdeptarr(dept);
  // }
  return (
    <div className="App">
     
      {/* <Loginverify></Loginverify> */}
      <Router>
        <Switch>
        {/* <Route path="/" exact 
          render={(props)=>(<Loginverify {...props} ></Loginverify>)}></Route> */}
          <Route path="/" exact 
          render={(props)=>(<DepartmentList {...props} ></DepartmentList>)}></Route>
          <Route path ="/add" exact
          render={(props)=>(<DepartmentAdd {...props}></DepartmentAdd>)}></Route>
          <Route path="/update/:id" exact
          render={(props)=>(<DepartmentUpdate {...props} id={props.match.params.id}></DepartmentUpdate>)}></Route>
        </Switch>
      </Router>
   
    </div>
  );
}

export default App;
