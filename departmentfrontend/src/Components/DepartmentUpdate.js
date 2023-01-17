import React from "react";
import DepartmentServices from "./DepartmentServices";
class DepartmentUpdate extends React.Component{

     constructor(props){
     super(props);
     this.state={
      id:"",
      name:"",
      location:""
     };
     }

     componentDidMount(){
        DepartmentServices.getDepartmentbyid(this.props.id).then((result)=>{
          this.setState({id:result.data.id,name:result.data.name,location:result.data.location})
          console.log(this.state.id);
          console.log(this.state.name);
          console.log(this.state.location);
        });
     }
     update =()=>{
        let dept = {id:this.state.id,name:this.state.name,location:this.state.location};
        console.log(dept)
        DepartmentServices.updatedept(dept).then((result)=>{
            this.props.history.push("/");
        }).catch((err)=>{
            console.log("error occured"+err);
        })
     }

     render(){
        return(
            <div>
             <form>
                Department ID: <input type="number" value={this.state.id}
                onChange={(event)=>this.setState({id:event.target.value})}></input><br></br>
                 Department Name: <input type="text" value={this.state.name}
                onChange={(event)=>this.setState({name:event.target.value})}></input><br></br>
                 Department Location: <input type="text" value={this.state.location}
                onChange={(event)=>this.setState({location:event.target.value})}></input><br></br>
                <button type="button" onClick={this.update}>Submit</button>
             </form>
            </div>
        )
     }
}
export default DepartmentUpdate;