import React,{Component} from 'react';
import {Table} from 'react-bootstrap';
import {Button, ButtonToolbar} from 'react-bootstrap';
import {AddHorseModal} from './AddHorseModal';
import {EditHorseModal} from './EditHorseModal';

export class Horse extends Component{

    constructor(props){
        super(props);
        this.state={horses:[], addModalShow:false, editModalShow:false, filterText:null}

        this.clearFilter = this.clearFilter.bind(this);
        this.handleFilterTextChange = this.handleFilterTextChange.bind(this);
    }

    refreshList(){
        var horseArr = [];

        fetch(process.env.REACT_APP_API+'horsejoinbreed')
        .then(response=>response.json())
        .then(data=>{
            if(this.state.filterText !== null)
            {
                horseArr = this.state.horses.filter(horse => horse.horse_name.includes(this.state.filterText));
                this.setState({horses:horseArr});
            }
            else
            {
                this.setState({horses:data});
            }
        });
    }

    componentDidMount(){
        this.refreshList();

    }

    componentDidUpdate(){
        this.refreshList();
    }

    deleteHorse(horseid){
        if(window.confirm('Are you sure?')){
            fetch(process.env.REACT_APP_API+'horses/'+horseid,{
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
        const {horses, horseid, horsename, horsedob, horsebreed, horsebreedid}=this.state;
        let addModalClose=()=>this.setState({addModalShow:false});
        let editModalClose=()=>this.setState({editModalShow:false});
        return(
            <div >
                <input 
                    type="text"
                    name="filterText"
                    placeHolder="Enter horse name..."
                    value={this.state.filterText}
                    onChange={this.handleFilterTextChange}
                />

                <button value="Send" onClick={this.clearFilter}>Clear Filter</button>
                
                <Table className="mt-4" striped bordered hover size="sm">
                    <thead>
                        <tr>
                            <th>Horse ID</th>
                            <th>Horse Name</th>
                            <th>Horse DOB</th>
                            <th>Horse Breed</th>
                            <th>Options</th>
                        </tr>
                    </thead>
                    <tbody>
                        {horses.map(horse=>
                            <tr key={horse.horse_id}>
                                <td>{horse.horse_id}</td>
                                <td>{horse.horse_name}</td>
                                <td>{this.getParsedDate(horse.horse_dob)}</td>
                                <td>{horse.breed_name}</td>
                                <td>
                                    <ButtonToolbar>
                                        <Button className="mr-2" variant="info"
                                        onClick={()=>this.setState({editModalShow:true,
                                            horseid:horse.horse_id,horsename:horse.horse_name,horsedob:horse.horse_dob,
                                            horsebreed:horse.breed_name,horsebreedid:horse.horse_breed_id })}>
                                            Edit
                                        </Button>

                                        <Button className="mr-2" variant="danger"
                                        onClick={()=>this.deleteHorse(horse.horse_id)}>
                                            Delete
                                        </Button>

                                        <EditHorseModal show={this.state.editModalShow}
                                        onHide={editModalClose}
                                        horseid={horseid}
                                        horsename={horsename} //this is how you reference it on modal form in props
                                        horsedob={horsedob}
                                        horsebreed={horsebreed}
                                        horsebreedid={horsebreedid}
                                        />
                                    </ButtonToolbar>
                                </td>
                            </tr>)}    
                    </tbody>
                </Table>
                
                <ButtonToolbar>
                    <Button variant='primary'
                    onClick={()=>this.setState({addModalShow:true})}>
                        Add Horse
                    </Button>

                    <AddHorseModal 
                        show={this.state.addModalShow}
                        onHide={addModalClose}/>
                </ButtonToolbar>
            </div>
        )
    }    
}