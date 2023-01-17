import React from "react";
import DepartmentServices from "./DepartmentServices";
class DepartmentAdd extends React.Component{
    constructor(props){
        super(props);
        this.state={
             id:"",
             name:"",
             location:""
        }
    }


    addDept=(event)=>{
        event.preventDefault();
        if(this.state.id === "" || this.state.name ==="" ||this.state.location === "")
        {
            alert("All fields are madantatory");
            this.props.history.push("/");
        }
        else{
            let dept={id:this.state.id,name:this.state.name,location:this.state.location}
        DepartmentServices.addDepartment(dept).then((result)=>{
            this.props.history.push("/");
        })
        }
        
    }
    render(){
        return(
            <div>
              <form >
                Department ID :<input type="number"  value={this.state.id}
                onChange={(event)=>this.setState({id:event.target.value})}></input><br></br>
                Department Name :<input type="text" value={this.state.name}
                onChange={(event)=>this.setState({name:event.target.value})}></input><br></br>
                Department Location : <input type="text" value={this.state.location}
                onChange={(event)=>this.setState({location:event.target.value})}></input><br></br>
                <button type="submit" onClick={this.addDept}>Submit</button>
              </form>
            </div>
        )
    }

}
export default DepartmentAdd;