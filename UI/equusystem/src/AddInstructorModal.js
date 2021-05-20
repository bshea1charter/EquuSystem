import React,{Component} from 'react';
import {Modal, Button, Row, Col, Form} from 'react-bootstrap';

export class AddInstructorModal extends Component{
    constructor(props){
        super(props);
        this.handleSubmit=this.handleSubmit.bind(this);
    }

    componentWillUnmount() {
        // fix Warning: Can't perform a React state update on an unmounted component
        //this.setState = (state,callback)=>{return;};
    }

    handleSubmit(event){
        //event.preventDefault(); --commenting this out closes window when done
        fetch(process.env.REACT_APP_API+'instructors',{
            method:'POST',
            headers:{'Content-Type':'application/json'},
            body:JSON.stringify({instructor_first_name:event.target.InstructorFirstName.value, instructor_last_name:event.target.InstructorLastName.value})
        })
    }

    render(){
        return (
            <div className="container">
                <Modal
                {...this.props}
                size="lg"
                //aria-labelledby="contained-modal-title-vcenter"
                centered>
                    <Modal.Header closeButton>
                        <Modal.Title id="contained-modal-title-vcenter">
                            Add Instructor
                        </Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <Row>
                            <Col sm={6}>
                                <Form onSubmit={this.handleSubmit}>
                                    <Form.Group controlId="InstructorFirstName">
                                        <Form.Label>First Name</Form.Label>
                                        <Form.Control type="text" name="InstructorFirstName" placeholder="InstructorFirstName"/>
                                    </Form.Group>

                                    <Form.Group controlId="InstructorLastName">
                                        <Form.Label>Last Name</Form.Label>
                                        <Form.Control type="text" name="InstructorLastName" placeholder="InstructorLastName"/>
                                    </Form.Group>

                                    <Form.Group>
                                        <div></div>
                                        <Button variant="primary" type="submit">
                                            Add Instructor
                                        </Button>
                                    </Form.Group>
                                </Form>
                            </Col>
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