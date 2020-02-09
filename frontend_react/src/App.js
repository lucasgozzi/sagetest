import React from 'react';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from "react-router-dom";

import Button from '@material-ui/core/Button';
import PeopleList from './pages/people-list';
import SaveIcon from '@material-ui/icons/Save';
import ListIcon from '@material-ui/icons/List';
import PeopleUpsert from './pages/people-upsert/index';

function App(props) {
  return (
    <Router>
      <div>
        <nav>
          <div>
            <ul>
              <li>
                <Link to="/"><Button size="large" startIcon={<ListIcon />}>Home</Button></Link>
              </li>
              <li>
                <Link to="/new-update"><Button size="large" startIcon={<SaveIcon />}>Novo</Button></Link>
              </li>
            </ul>
          </div>
          <img src={process.env.PUBLIC_URL + "lgo_sage.png"} alt="Sage Logo" />
        </nav>

        {/* A <Switch> looks through its children <Route>s and
            renders the first one that matches the current URL. */}
        <Switch>
          <Route path="/new-update/:id">
            <PeopleUpsert {...props} />
          </Route>
          <Route path="/new-update">
            <PeopleUpsert {...props} />
          </Route>
          <Route path="/">
            <PeopleList {...props} />
          </Route>
        </Switch>
      </div>
    </Router>
  );
}

export default App;
