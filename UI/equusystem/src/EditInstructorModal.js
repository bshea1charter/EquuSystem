import React,{Component} from 'react';
import {Modal, Button, Row, Form} from 'react-bootstrap';

export class EditInstructorModal extends Component{
    constructor(props){
        super(props);

        var boolAdmin=false;

        if (this.props.instructoradmin===1)
        {
            boolAdmin=true;
        }

        this.state={ isAdmin: boolAdmin};
        this.handleSubmit=this.handleSubmit.bind(this);
        this.handleCBInputChange = this.handleCBInputChange.bind(this);
    }

    handleSubmit(event){
            //event.preventDefault();  --commenting this out closes window after done
            var intAdmin=0;

            if (this.state.isAdmin===true)
            {
                intAdmin=1;
            }

            fetch(process.env.REACT_APP_API+'instructors/'+this.props.instructorid.toString(),{
            method:'PUT',
            headers:{'Accept':'application/json','Content-Type':'application/json'},
            body:JSON.stringify({instructor_first_name:event.target.InstructorFirstName.value, 
                                 instructor_last_name:event.target.InstructorLastName.value,
                                 instructor_phone:event.target.InstructorPhone.value,
                                 instructor_user_id:event.target.InstructorUserId.value,
                                 instructor_password:event.target.InstructorPassword.value,
                                 instructor_admin:intAdmin.toString(),
                                 instructor_core_rate:event.target.InstructorCoreRate.value,
                                 instructor_session_rate:event.target.InstructorSessionRate.value,
                                 instructor_over_head_rate:event.target.InstructorOverHeadRate.value,
                                 instructor_session_over_head_rate:event.target.InstructorSessionOverHeadRate.value,
                                 instructor_training_rate:event.target.InstructorTrainingRate.value
                                 })
        })
    }

    componentWillUnmount() {
        // fix Warning: Can't perform a React state update on an unmounted component
        //this.setState = (state,callback)=>{return;};
    }

    handleCBInputChange(event) {
        const target = event.target;
        const value = target.type === 'checkbox' ? target.checked : target.value;
        const name = target.name;
    
        this.setState({
          [name]: value
        });
      }

    render(){
        return (
            <div className="container">
                <Modal
                {...this.props}
                size="lg"
                aria-labelledby="contained-modal-title-vcenter"
                centered>

                    <Modal.Header closeButton>
                        <Modal.Title id="contained-modal-title-vcenter">
                            Edit Instructor
                        </Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <Row>
                            <Form onSubmit={this.handleSubmit}>
                                <div class="col-md-10">
                                    <div class="form-group row">
                                        <div class="col-sm-6">
                                            <label for="InstructorId">Instructor Id</label>
                                            <input type="text" size="50" class="form-control"  placeholder="Instructor Id"
                                            defaultValue={this.props.instructorid}
                                            disabled />
                                        </div>
                                        <div class="col">
                                            <label for="InstructorAdmin" class="float-right" style={{marginLeft:10, marginTop:6, alignSelf:'flex-end'}}>Is Admin
                                            <input type="checkbox" size="50" style={{marginLeft:10, marginTop:10, alignSelf:'flex-end'}}
                                            id="isAdmin" 
                                            name="isAdmin"
                                            placeholder="Instructor Admin"
                                            checked={this.state.isAdmin}
                                            onChange={this.handleCBInputChange} />
                                            </label>
                                        </div>
                                    </div>

                                    <div class="form-group row">
                                        <div class="col">
                                            <label for="InstructorFirstName">First Name</label>
                                            <input type="text" size="10" class="form-control" name="InstructorFirstName" placeholder="First Name"
                                            defaultValue={this.props.instructorfirstname} />
                                        </div>
                                        <div class="col">
                                            <label for="InstructorLastName">Last name</label>
                                            <input type="text" size="75" class="form-control" name="InstructorLastName" placeholder="Last Name"
                                            defaultValue={this.props.instructorlastname} />
                                        </div>
                                        <div class="col-sm-6">
                                            <label for="InstructorPhone">Address</label>
                                            <Form.Control type="text" class="form-control" name="InstructorPhone" placeholder="Phone #" 
                                            defaultValue={this.props.instructorphone} />
                                        </div>
                                    </div>
                                    
                                    <div class="form-group row">
                                        <div class="col">
                                            <label for="InstructorUserId">User Id</label>
                                            <input type="text" size="10" class="form-control" name="InstructorUserId" placeholder="User Id"
                                            defaultValue={this.props.instructoruserid} />
                                        </div>
                                        <div class="col">
                                            <label for="InstructorPassword">User Password</label>
                                            <input type="text" size="10" class="form-control" name="InstructorPassword" placeholder="User Password"
                                            defaultValue={this.props.instructorpassword} />
                                        </div>
                                    </div>

                                    <div class="form-group row">
                                        <div class="col">
                                            <label for="InstructorCoreRate">Core Rate</label>
                                            <input type="text" size="10" class="form-control" name="InstructorCoreRate" placeholder="Core Rate"
                                            defaultValue={this.props.instructorcorerate} />
                                        </div>
                                        <div class="col">
                                            <label for="InstructorSessionRate">Session Rate</label>
                                            <input type="text" size="10" class="form-control" name="InstructorSessionRate" placeholder="Session Rate"
                                            defaultValue={this.props.instructorsessionrate} />
                                        </div>
                                        <div class="col">
                                            <label for="InstructorOverHeadRate">Session Rate</label>
                                            <input type="text" size="10" class="form-control" name="InstructorOverHeadRate" placeholder="Overhead Rate"
                                            defaultValue={this.props.instructoroverheadrate} />
                                        </div>
                                    </div>

                                    <div class="form-group row">
                                        <div class="col">
                                            <label for="InstructorSessionOverHeadRate">Core Rate</label>
                                            <input type="text" size="10" class="form-control" name="InstructorSessionOverHeadRate" placeholder="Session Overhead Rate"
                                            defaultValue={this.props.instructorsessionoverheadrate} />
                                        </div>
                                        <div class="col">
                                            <label for="InstructorTrainingRate">Session Rate</label>
                                            <input type="text" size="10" class="form-control" name="InstructorTrainingRate" placeholder="Training Rate"
                                            defaultValue={this.props.instructortrainingrate} />
                                        </div>
                                    </div>

                                    <button variant="primary" type="submit" class="btn btn-primary px-4 float-right">Save</button>
                                </div>
                            </Form>
                        </Row>
                    </Modal.Body>
                <Modal.Footer>
                    <Button variant="danger" onClick={this.props.onHide}>Cancel</Button>
                </Modal.Footer>
            </Modal>
        </div>
        )
    }
}