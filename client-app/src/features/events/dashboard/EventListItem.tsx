import React from "react";
import { Link } from "react-router-dom";
import { Button, Icon, Item, Label, Segment } from 'semantic-ui-react';
import { Activity } from "../../../app/models/activity";
import { format } from "date-fns";
import EventListItemAttendee from './EventListItemAttendee';

interface Props {
  activity: Activity;
}
export default function EventListItem({ activity }: Props) {
  return (
    <Segment.Group>
      <Segment>
        {activity.isCancelled &&
          <Label attached='top' color='red' content='Cancelled' style={{ textAlign: 'center' }} />
        }
        <Item.Group>
          <Item>
            <Item.Image style={{ marginBottom: 3 }} size='tiny' circular src='/assets/user.png' />
            <Item.Content>
              <Item.Header as={Link} to={`/events/${activity.id}`}>
                {activity.title}
              </Item.Header>
              <Item.Description>Hosted by {activity.host?.displayName}</Item.Description>
              {activity.isHost && (
                <Item.Description>
                  <Label basic color="orange">
                    You are hosting this Event
                  </Label>
                </Item.Description>
              )}
              {activity.isGoing && !activity.isHost && (
                <Item.Description>
                  <Label basic color="green">
                    You are going to this Event
                  </Label>
                </Item.Description>
              )}
            </Item.Content>
          </Item>
        </Item.Group>
      </Segment>
      <Segment>
        <span>
          <Icon name="clock" /> {format(activity.date!, "dd MM yyyy h:mm aa")}
          <Icon name="marker" /> {activity.venue}
        </span>
      </Segment>
      <Segment secondary>
        <EventListItemAttendee attendees={activity.attendees!} />
      </Segment>
      <Segment clearing>
        <span>{activity.description}</span>
        <Button
          as={Link}
          to={`/events/${activity.id}`}
          color="teal"
          floated="right"
          content="View"
        />
      </Segment>
    </Segment.Group>
  );
}
