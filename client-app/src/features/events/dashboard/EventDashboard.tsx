import React from "react";
import { Grid } from "semantic-ui-react";
import { Activity } from "../../../app/models/activity";
import EventDetails from "../details/EventDetails";
import EventForm from "../form/EventForm";
import EventList from "./EventList";

interface Props {
  activities: Activity[];
  selectedActivity: Activity | undefined;
  selectActivity: (id: string) => void;
  cancelSelectActivity: () => void;
  editMode: boolean;
  openForm: (id: string) => void;
  closeForm: () => void;
  createOrEdit: (activity: Activity) => void;
  deleteActivity: (id: string) => void;
}
export default function EventDashboard({
  activities,
  selectedActivity,
  selectActivity,
  cancelSelectActivity,
  editMode,
  openForm,
  closeForm,
  createOrEdit,
  deleteActivity
}: Props) {
  return (
    <Grid>
      <Grid.Column width="10">
        <EventList activities={activities} selectActivity = {selectActivity} deleteActivity = {deleteActivity} />
      </Grid.Column>
      <Grid.Column width="6">
        {selectedActivity && !editMode && <EventDetails activity={selectedActivity} cancelSelectActivity = {cancelSelectActivity} openForm = {openForm}/>}
       {editMode && <EventForm closeForm = {closeForm} activity = {selectedActivity} createOrEdit = {createOrEdit} /> }
      </Grid.Column>
    </Grid>
  );
}
