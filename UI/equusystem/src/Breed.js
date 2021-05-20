import React,{Component} from 'react';
import {Table} from 'react-bootstrap';
import {Button, ButtonToolbar} from 'react-bootstrap';
import {AddBreedModal} from './AddBreedModal';
import {EditBreedModal} from './EditBreedModal';

export class Breed extends Component{

    constructor(props){
        super(props);
        this.state={deps:[], addModalShow:false, editModalShow:false}
    }

    refreshList(){
        fetch(process.env.REACT_APP_API+'breeds')
        .then(response=>response.json())
        .then(data=>{
            this.setState({deps:data});
        });
    }

    componentDidMount(){
        this.refreshList();
    }

    componentDidUpdate(){
        this.refreshList();
    }

    deleteBreed(breedid){
        if(window.confirm('Are you sure?')){
            fetch(process.env.REACT_APP_API+'breeds/'+breedid,{
                method:'DELETE',
                header:{'Accept':'application/json',
                        'Content-Type':'applicaton/json'}
            })    
        }
    }

    render(){
        const {deps, breedid, breedname}=this.state;
        let addModalClose=()=>this.setState({addModalShow:false});
        let editModalClose=()=>this.setState({editModalShow:false});
        return(
            <div >
                <Table className="mt-4" striped bordered hover size="sm">
                    <thead>
                        <tr>
                            <th>Breed ID</th>
                            <th>Breed Name</th>
                            <th>Options</th>
                        </tr>
                    </thead>
                    <tbody>
                        {deps.map(dep=>
                            <tr key={dep.breed_id}>
                                <td>{dep.breed_id}</td>
                                <td>{dep.breed_name}</td>
                                <td>
                                    <ButtonToolbar>
                                        <Button className="mr-2" variant="info"
                                        onClick={()=>this.setState({editModalShow:true,
                                            breedid:dep.breed_id,breedname:dep.breed_name})}>
                                            Edit
                                        </Button>

                                        <Button className="mr-2" variant="danger"
                                        onClick={()=>this.deleteBreed(dep.breed_id)}>
                                            Delete
                                        </Button>

                                        <EditBreedModal show={this.state.editModalShow}
                                        onHide={editModalClose}
                                        breedid={breedid}
                                        breedname={breedname}
                                        />
                                    </ButtonToolbar>
                                </td>
                            </tr>)}    
                    </tbody>
                </Table>
                
                <ButtonToolbar>
                    <Button variant='primary'
                    onClick={()=>this.setState({addModalShow:true})}>
                        Add Breed
                    </Button>

                    <AddBreedModal 
                        show={this.state.addModalShow}
                        onHide={addModalClose}>
                    </AddBreedModal>
                </ButtonToolbar>
            </div>
        )
    }    
}