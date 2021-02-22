import { observer } from "mobx-react-lite";
import React from "react";
import { Grid } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import EventDetails from "../details/EventDetails";
import EventForm from "../form/EventForm";
import EventList from "./EventList";

export default observer(function EventDashboard() {
  const { activityStore } = useStore();
  const { selectedActivity, editMode } = activityStore;
  return (
    <Grid>
      <Grid.Column width="10">
        <EventList />
      </Grid.Column>
      <Grid.Column width="6">
        {selectedActivity && !editMode && <EventDetails />}
        {editMode && <EventForm />}
      </Grid.Column>
    </Grid>
  );
});
