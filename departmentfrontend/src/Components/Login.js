import Loginservices from "./Loginservices";
import React from "react";
class Login extends React.Component{
    constructor(props){
        super(props);
        this.state={
            logarr:[],
            filterlogarr:[]
        }
    }

    componentDidMount(){
        Loginservices.getLogins().then((result)=>{
            this.setState({logarr:result.data,filterlogarr:result.data})
        })
    }

    render(){
        return(
           <div>
            <div className="row">
                    <table className="table table-stripped table-bordered">
                        <thead>
                            <tr>
                                <th>Email</th>
                                <th>Password</th>
                               
                            </tr>
                        </thead>
                        <tbody>
                            {
                                this.state.filterlogarr.map((logi,index)=>
                                <tr key={index}>
                                    <td>{logi.email}</td>
                                    <td>{logi.password}</td>
                                    {/* <td>{dept.location}</td> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <td><button type="button" name="btn" onClick={()=>{this.delete(dept.id)}}>Delete</button></td> */}
                                </tr>)
                            }
                        </tbody>
                    </table>
                </div>
           </div>
        );
    }
}
export default Login;