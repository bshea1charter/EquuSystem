import React,{Component} from 'react';
import logo from './GRS-logo.jpg';

export class Home extends Component{
    render(){
        return(
            <div>
                <font size="15" className="d-flex justify-content-center">Golden Ridge Stables - Home</font>
                <div className="logo">
                    <img src={logo} width="750" height="450" margin-left="auto" margin-right="auto" />
                </div>
            </div>

            
        )
    }    
}