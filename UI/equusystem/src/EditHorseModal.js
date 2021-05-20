import React,{Component} from 'react';
import {Modal, Button, Row, Col, Form} from 'react-bootstrap';

export class EditHorseModal extends Component{
    constructor(props){
        super(props);
        this.state={breeds:[]};
        this.handleSubmit=this.handleSubmit.bind(this);
    }

    handleSubmit(event){
            //event.preventDefault();  --commenting this out closes window after done
            fetch(process.env.REACT_APP_API+'horses/'+this.props.horseid.toString(),{
            method:'PUT',
            headers:{'Accept':'application/json','Content-Type':'application/json'},
            body:JSON.stringify({horse_name:event.target.HorseName.value, horse_breed_id:String(event.target.HorseBreedId.childNodes[event.target.HorseBreedId.selectedIndex].id),
                                 horse_dob:event.target.HorseDOB.value})

        })
    }

    componentWillUnmount() {
        // fix Warning: Can't perform a React state update on an unmounted component
        //this.setState = (state,callback)=>{return;};
    }


    componentDidMount() {
        fetch(process.env.REACT_APP_API+'breeds')
        .then(response => response.json())
        .then(data => this.setState({'breeds': data}))
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
        date =  yyyy + "-" + mm + "-" + dd;
        //date =  mm + "/" + dd + "/" + yyyy;
        return date.toString();
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
                            Edit Horse
                        </Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <Row>
                            <Col sm={6}>
                                <Form onSubmit={this.handleSubmit}>
                                    <Form.Group controlId="HorseId">
                                        <Form.Label>Horse ID</Form.Label>
                                        <Form.Control type="text" name="Horse Id" placeholder="HorseId" required
                                        disabled
                                        defaultValue={this.props.horseid}/>
                                    </Form.Group>

                                    <Form.Group controlId="HorseName">
                                        <Form.Label>Horse Name</Form.Label>
                                        <Form.Control type="text" name="HorseName" 
                                        defaultValue={this.props.horsename}
                                        placeholder="HorseName"/>
                                    </Form.Group>

                                    <Form.Group controlId="HorseBreedId">
                                        <Form.Label>Horse Breed</Form.Label>
                                        <Form.Control as="select" defaultValue={this.props.horsebreed}>
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
                                        placeholder="HorseDOB"
                                        dateFormat="yyyy-mm-dd"
                                        defaultValue={this.getParsedDate(this.props.horsedob)}/>
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