import React from 'react';
import Calendar from 'react-calendar';
import { Header, Menu } from 'semantic-ui-react';

export default function EventFilters(){
    return (
      <>
        <Menu vertical size = "large" style = {{width: "100%", marginTop: 25}}>
            <Header icon = "filter" attached color = "teal" content = "Filters" />
        <Menu.Item content = "All Events" />
        <Menu.Item content = "I am going" />
        <Menu.Item content = "I amd hosting"/>
        </Menu>
        <Header />
        <Calendar />
      </>
    )
}