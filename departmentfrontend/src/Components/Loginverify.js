import React from "react";
import Loginservices from "./Loginservices";
class Loginverify extends React.Component{
    constructor(props){
        super(props);
        this.state={
             email:"",
             password:"",
             logarr:[],
             filterlogarr:[],
             department:{}
        };
    }


 
    componentDidMount(){
        Loginservices.getLogins().then((result)=>{
            this.setState({logarr:result.data,filterlogarr:result.data})
        })
    }

    verify=(event)=>{
         event.preventDefault();
        this.setState({department:this.state.logarr.filter((dept)=>{
            return dept.email.includes(this.state.email) && dept.password.includes(this.state.password) 
        })})
        console.log(this.state.department)
        if(JSON.stringify(this.state.department) === '{}')
        {
            this.setState({email:"",password:""})
            alert("invalid password")
        }
        else{
            this.props.history.push("/home");
        }
    }


    render(){
        return(
            <div>
              <form >
                Email :<input type="text"  value={this.state.email}
                onChange={(event)=>this.setState({email:event.target.value})}></input><br></br>
                Password :<input type="password" value={this.state.password}
                onChange={(event)=>this.setState({password:event.target.value})}></input><br></br>
                <button type="submit" onClick={this.verify}>Submit</button>
              </form>
            </div>
        )
    }

}
export default Loginverify;