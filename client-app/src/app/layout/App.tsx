import React, { Component, useState, useEffect } from 'react';
import axios from 'axios';
import {Header, HeaderContent, Icon, List} from 'semantic-ui-react';
import {IActivity} from '../models/activity';


function App()
{
  const [activities,setActivity] = useState<IActivity[]>([]);

  useEffect(() =>
  {
    axios
    .get<IActivity[]>('https://localhost:5001/api/Events/GetAll')
    .then(response =>
      {
        setActivity(response.data)
      }
      );
  },[]);
  
  return (
    <div>
    <Header as = 'h2'>
      <Icon name = 'users' />
      <Header.Content>Events</Header.Content>
      </Header>
      <List>
        {
          activities.map(activity => {
            <List.Item key = {activity.id}>{activity.title}</List.Item>
          })
        }
      </List>
    </div>
  );
}

export default App;
