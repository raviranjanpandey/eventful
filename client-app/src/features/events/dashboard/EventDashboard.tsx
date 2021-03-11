import { observer } from "mobx-react-lite";
import React, { useEffect } from "react";
import { Grid } from "semantic-ui-react";
import LoadingComponent from "../../../app/layout/LoadingComponent";
import { useStore } from "../../../app/stores/store";
import EventList from "./EventList";

export default observer(function EventDashboard() {
  const { activityStore } = useStore();
  const { loadActivities, activityRegistry } = activityStore;

  useEffect(() => {
    if(activityRegistry.size <= 1) loadActivities();
  }, [activityRegistry.size,loadActivities]);

  if (activityStore.loadingInitial)
    return <LoadingComponent content="Loading app..." />;
  return (
    <Grid>
      <Grid.Column width="10">
        <EventList />
      </Grid.Column>
      <Grid.Column width="6">
        <h2>Activity Filters</h2>
      </Grid.Column>
    </Grid>
  );
});
