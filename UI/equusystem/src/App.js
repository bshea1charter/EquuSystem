import './App.css';
import {Home} from './Home';
import {Breed} from './Breed';
import {Horse} from './Horse';
import {Instructor} from './Instructor';
import {Navigation} from './Navigation';

import {BrowserRouter, Route, Switch} from 'react-router-dom';

function App() {
  return (
    <BrowserRouter>
    <div className="container">
      <h3 className="m-3 d-flex justify-content-center">
        EquuSystem Equine Management  
      </h3>

      <Navigation/>
      <Switch>
        <Route path='/' component={Home} exact/>
        <Route path='/breed' component={Breed}/>
        <Route path='/horse' component={Horse}/>
        <Route path='/instructor' component={Instructor}/>
      </Switch>
    </div>
    </BrowserRouter>
  );
}

export default App;
