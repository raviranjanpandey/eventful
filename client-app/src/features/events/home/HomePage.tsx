import React from "react";
import { Link } from "react-router-dom";
import { Button, Container, Header, Image, Segment } from "semantic-ui-react";

export default function HomePage(){
return (
    <Segment inverted textAlign = "center" vertical className = "masthead">
        <Container text>
            <Header as = "h1" inverted>
                <Image size = "massive" src ="/assets/logo.png" alt = "logo" style= {{marginBottom: 12}} />
                Eventful
            </Header>
            <Header as = "h2" inverted content = "Welcome to Eventful."/>
            <Button as = {Link} to = "/events" size = "huge" inverted>Go to Events</Button>
        </Container>
    </Segment>
)
}