import React,{Component} from 'react';
import {Table} from 'react-bootstrap';
import {Button, ButtonToolbar} from 'react-bootstrap';
import {AddInstructorModal} from './AddInstructorModal';
import {EditInstructorModal} from './EditInstructorModal';

export class Instructor extends Component{

    constructor(props){
        super(props);
        this.state={instructors:[], addModalShow:false, editModalShow:false, filterText:null}

        this.clearFilter = this.clearFilter.bind(this);
        this.handleFilterTextChange = this.handleFilterTextChange.bind(this);
    }

    refreshList(){
        var instructorArr = [];

        fetch(process.env.REACT_APP_API+'instructors')
        .then(response=>response.json())
        .then(data=>{
            if(this.state.filterText !== null)
            {
                instructorArr = this.state.instructors.filter(instructor => instructor.instructor_last_name.includes(this.state.filterText));
                this.setState({instructors:instructorArr});
            }
            else
            {
                this.setState({instructors:data});
            }
        });
    }

    componentDidMount(){
        this.refreshList();

    }

    componentDidUpdate(){
        this.refreshList();
    }

    deleteInstructor(instructorid){
        if(window.confirm('Are you sure?')){
            fetch(process.env.REACT_APP_API+'instructors/'+instructorid,{
                method:'DELETE',
                header:{'Accept':'application/json',
                        'Content-Type':'applicaton/json'}
            })    
        }
    }

    handleFilterTextChange({ target }){
        this.setState({ [target.name]: target.value});
    }
    
    clearFilter(){
        //this.refs.fltTxt.value = '';
        this.setState({filterText: null});
        this.refreshList();
    }


    getParsedDate(strDate){
        var strSplitDate = String(strDate).split(' ');
        var date = new Date(strSplitDate[0]);
        // alert(date);
        var dd = date.getDate();
        var mm = date.getMonth() + 1; //January is 0!
    
        var yyyy = date.getFullYear();
        if (dd < 10) {
            dd = '0' + dd;
        }
        if (mm < 10) {
            mm = '0' + mm;
        }
        //date =  yyyy + "-" + mm + "-" + dd;
        date =  mm + "/" + dd + "/" + yyyy;
        return date.toString();
    }

    render(){
        const {instructors, instructorid, instructorfirstname, instructorlastname, instructorphone, instructoruserid,
               instructorpassword, instructoradmin, instructorcorerate, instructorsessionrate, instructoroverheadrate,
               instructorsessionoverheadrate, instructortrainingrate}=this.state;
        let addModalClose=()=>this.setState({addModalShow:false});
        let editModalClose=()=>this.setState({editModalShow:false});
        return(
            <div >
                <input 
                    type="text"
                    name="filterText"
                    placeHolder="Last Name..."
                    value={this.state.filterText}
                    onChange={this.handleFilterTextChange}
                />

                <button value="Send" onClick={this.clearFilter}>Clear Filter</button>
                
                <Table className="mt-4" striped bordered hover size="sm">
                    <thead>
                        <tr>
                            <th>Instructor ID</th>
                            <th>Instructor First Name</th>
                            <th>Instructor Last Name</th>
                            <th>Instructor User ID</th>
                            <th>Options</th>
                        </tr>
                    </thead>
                    <tbody>
                        {instructors.map(instructor=>
                            <tr key={instructor.instructor_id}>
                                <td>{instructor.instructor_id}</td>
                                <td>{instructor.instructor_first_name}</td>
                                <td>{instructor.instructor_last_name}</td>
                                <td>{instructor.instructor_user_id}</td>
                                <td>
                                    <ButtonToolbar>
                                        <Button className="mr-2" variant="info"
                                        onClick={()=>this.setState({editModalShow:true,
                                            instructorid:instructor.instructor_id,
                                            instructorfirstname:instructor.instructor_first_name,
                                            instructorlastname:instructor.instructor_last_name, 
                                            instructoruserid:instructor.instructor_user_id, 
                                            instructorphone:instructor.instructor_phone,
                                            instructorpassword:instructor.instructor_password, 
                                            instructoradmin:instructor.instructor_admin, 
                                            instructorcorerate:instructor.instructor_core_rate, 
                                            instructorsessionrate:instructor.instructor_session_rate, 
                                            instructoroverheadrate:instructor.instructor_over_head_rate,
                                            instructorsessionoverheadrate:instructor.instructor_session_over_head_rate, 
                                            instructortrainingrate:instructor.instructor_training_rate })}>
                                            Edit
                                        </Button>

                                        <Button className="mr-2" variant="danger"
                                        onClick={()=>this.deleteInstructor(instructor.instructor_id)}>
                                            Delete
                                        </Button>

                                        <EditInstructorModal show={this.state.editModalShow}
                                        onHide={editModalClose}
                                        instructorid={instructorid}
                                        instructorfirstname={instructorfirstname} 
                                        instructorlastname={instructorlastname}
                                        instructorphone={instructorphone}
                                        instructoruserid={instructoruserid}
                                        instructorpassword={instructorpassword}
                                        instructoradmin={instructoradmin}
                                        instructorcorerate={instructorcorerate}
                                        instructorsessionrate={instructorsessionrate}
                                        instructoroverheadrate={instructoroverheadrate}
                                        instructorsessionoverheadrate={instructorsessionoverheadrate}
                                        instructortrainingrate={instructortrainingrate}
                                        />
                                    </ButtonToolbar>
                                </td>
                            </tr>)}    
                    </tbody>
                </Table>
                
                <ButtonToolbar>
                    <Button variant='primary'
                    onClick={()=>this.setState({addModalShow:true})}>
                        Add Instructor
                    </Button>

                    <AddInstructorModal 
                        show={this.state.addModalShow}
                        onHide={addModalClose}/>
                </ButtonToolbar>
            </div>
        )
    }    
}