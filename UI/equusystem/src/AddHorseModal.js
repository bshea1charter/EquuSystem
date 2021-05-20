import React,{Component} from 'react';
import {Modal, Button, Row, Col, Form} from 'react-bootstrap';

export class AddHorseModal extends Component{
    constructor(props){
        super(props);
        this.state={breeds:[]};

        this.handleSubmit=this.handleSubmit.bind(this);
    }

    componentDidMount() {
        fetch(process.env.REACT_APP_API+'breeds')
        .then(response => response.json())
        .then(data => this.setState({'breeds': data}))
    }    

    componentWillUnmount() {
        // fix Warning: Can't perform a React state update on an unmounted component
        //this.setState = (state,callback)=>{return;};
    }

    //onCreateBreed(){
    handleSubmit(event){
        //event.preventDefault(); --commenting this out closes window when done
        fetch(process.env.REACT_APP_API+'horses',{
            method:'POST',
            headers:{'Content-Type':'application/json'},
            body:JSON.stringify({horse_name:event.target.HorseName.value, horse_breed_id:String(event.target.HorseBreedId.childNodes[event.target.HorseBreedId.selectedIndex].id),
                                 horse_dob:event.target.HorseDOB.value})
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
                            Add Horse
                        </Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <Row>
                            <Col sm={6}>
                                <Form onSubmit={this.handleSubmit}>
                                    <Form.Group controlId="HorseName">
                                        <Form.Label>Horse Name</Form.Label>
                                        <Form.Control type="text" name="HorseName" placeholder="HorseName"/>
                                    </Form.Group>

                                    <Form.Group controlId="HorseBreedId">
                                        <Form.Label>Horse Breed</Form.Label>
                                        <Form.Control as="select">
                                            {this.state.breeds.map(breed=>
                                                <option id={breed.breed_id}>{breed.breed_name}</option>)}
                                        </Form.Control>
                                    </Form.Group>

                                    <Form.Group controlId="HorseDOB">
                                        <Form.Label>Horse DOB</Form.Label>
                                        <Form.Control
                                        type="date"
                                        name="HorseDOB"
                                        required
                                        placeholder="HorseDOB"/>
                                    </Form.Group>

                                    <Form.Group>
                                        <div></div>
                                        <Button variant="primary" type="submit">
                                            Add Horse
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