import { observer } from "mobx-react-lite";
import React, { Fragment } from "react";
import { Header } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import EventListItem from "./EventListItem";

export default observer(function EventList() {
  const { activityStore } = useStore();
  const { groupedActivities } = activityStore;

  return (
    <>
      {groupedActivities.map(([group, activities]) => (
        <Fragment key={group}>
          <Header sub color="teal">
            {group}
          </Header>      
              {activities.map((activity) => (
                <EventListItem activity={activity} key={activity.id} />
              ))}
        </Fragment>
      ))}
    </>
  );
});
