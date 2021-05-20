import React,{Component} from 'react';
import {Modal, Button, Row, Col, Form} from 'react-bootstrap';
import { Breed } from './Breed';

export class EditBreedModal extends Component{
    constructor(props){
        super(props);
        this.state={message:'',
                    Breed: {TheBreedId: props.breedid, TheBreedName: props.breed_name},
                    showModal: false
                   };
        this.handleSubmit=this.handleSubmit.bind(this)
    }

    onBreedNameChanged(event) {
        var TheBreed = this.state.Breed;
        TheBreed.TheBreedName = event.target.value;

        this.setState({ Breed: Breed })

    }

    componentWillUnmount() {
        // fix Warning: Can't perform a React state update on an unmounted component
        this.setState = (state,callback)=>{
            return;
        };
    }

    handleSubmit(event){
            fetch(process.env.REACT_APP_API+'breeds/'+this.props.breedid.toString(),{
            method:'PUT',
            headers:{'Accept':'application/json','Content-Type':'application/json'},
            body:JSON.stringify({
                breed_name:this.state.Breed.TheBreedName})
        })
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
                            Edit Breed
                        </Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <Row>
                            <Col sm={6}>
                                <Form onSubmit={this.handleSubmit}>
                                    <Form.Group controlId="BreedId">
                                        <Form.Label>Breed ID</Form.Label>
                                        <Form.Control type="text" name="Breed Id" placeholder="BreedId" required
                                        disabled
                                        defaultValue={this.props.breedid}/>
                                    </Form.Group>

                                    <Form.Group controlId="BreedName">
                                        <Form.Label>Breed Name</Form.Label>
                                        <Form.Control type="text" name="BreedName" placeholder="BreedName"
                                        value={this.state.Breed.TheBreedName} 
                                        onChange={this.onBreedNameChanged.bind(this)} required
                                        defaultValue={this.props.breedname}/>
                                    </Form.Group>

                                    <Form.Group>
                                        <Button variant="primary" type="submit">Save</Button>
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