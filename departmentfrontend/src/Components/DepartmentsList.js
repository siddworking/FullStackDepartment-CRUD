import DepartmentServices from "./DepartmentServices";
import React from "react";
class DepartmentsList extends React.Component{
    constructor(props){
        super(props);
        this.state={
            deptarr:[],
            searcharr:[],
            searchtext:"",
            sortingarr:[],
            flag:false
        }
    }

    componentDidMount(){
        DepartmentServices.getDepartments().then((response)=>{
            this.setState({deptarr:response.data,searcharr:response.data})
        })
    };

    componentDidUpdate(prevprops,prevstate){
        if(this.state.flag)
        {
            DepartmentServices.getDepartments().then((response)=>{
                this.setState({deptarr:response.data,searcharr:response.data,flag:false})
            })
        }
        if(prevstate.searchtext !== this.state.searchtext)
        {
            if(this.state.searchtext ===""){
                this.setState({searcharr:this.state.deptarr})
            }
            else
            {
             this.setState({searcharr:this.state.deptarr.filter((dept)=>{
                return dept.name.includes(this.state.searchtext)
             })})

            }
        }
        // if( prevstate.sortingarr !== this.state.sortingarr)
        // {
        //     if(this.state.sortingarr === [])
        //     {
        //         this.setState({searcharr:this.state.deptarr});
        //     }
        //     else
        //     {
        //         this.state.sortingarr.sort((a,b)=>{
        //             let fa = a.name.toLowerCase(),
        //                 fb = b.name.toLowerCase();
                     
        //             if(fa < fb)
        //             {
        //                 return -1;
        //             }  
        //             if(fa > fb)
        //             {
        //                 return 1;
        //             }  
        //             return 0;

        //         });
        //         this.setState({searcharr:this.state.sortingarr,sortingarr:[]});
                
        //     }
        //     this.setState({sortingarr:[]})

        // }
    }

    addDept =()=>{
        this.props.history.push("/add");

    };

    sortdept=()=>{
        this.setState({sortingarr:this.state.deptarr});
     
    }

    delete=(deptid)=>{
        DepartmentServices.deletedept(deptid).then((result)=>{
         this.setState({flag:true})
        })

    }

    update=(id)=>{
        this.props.history.push(`update/${id}`)
    }

    render(){
        return(
            <div>
                <div>
                    <button type="button" onClick={this.addDept}>Add Department</button>
                </div>
                <div>
                    <button type="button" onClick={this.sortdept}>Sort on Department Names</button>
                </div>
                <div>
                   Search : <input type="text" value={this.state.searchtext}
                   onChange={(event)=>(this.setState({searchtext:event.target.value}))}></input><br></br>
                </div>
                <div className="row">
                    <table className="table table-stripped table-bordered">
                        <thead>
                            <tr>
                                <th>Dept id</th>
                                <th>Dept name</th>
                                <th>Location</th>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                this.state.searcharr.map((dept,index)=>
                                <tr key={index}>
                                    <td>{dept.id}</td>
                                    <td>{dept.name}</td>
                                    <td>{dept.location}</td> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <td><button type="button" name="btn" onClick={()=>{this.delete(dept.id)}}>Delete</button></td>
                                    <td><button type="button" name="btn1"onClick={()=>{this.update(dept.id)}}>Update</button></td>
                                </tr>)
                            }
                        </tbody>
                    </table>
                </div>
            </div>
        )
    }
}

export default DepartmentsList;