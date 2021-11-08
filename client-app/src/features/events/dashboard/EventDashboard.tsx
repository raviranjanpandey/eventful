import { observer } from "mobx-react-lite";
import React, { useEffect, useState } from "react";
import InfiniteScroll from "react-infinite-scroller";
import { Grid, Loader } from "semantic-ui-react";
import LoadingComponent from "../../../app/layout/LoadingComponent";
import { PagingParams } from "../../../app/models/pagination";
import { useStore } from "../../../app/stores/store";
import EventFilters from "./EventFilters";
import EventList from "./EventList";
import EventListItemPlaceholder from "./EventListItemPlaceholder";

export default observer(function ActivityDashboard() {
  const { activityStore } = useStore();
  const { loadActivities, activityRegistry, setPagingParams, pagination } = activityStore;
  const [loadingNext, setLoadingNext] = useState(false);

  function handleGetNext() {
      setLoadingNext(true);
      setPagingParams(new PagingParams(pagination!.currentPage + 1))
      loadActivities().then(() => setLoadingNext(false));
  }

  useEffect(() => {
      if (activityRegistry.size <= 1) loadActivities();
  }, [activityRegistry.size, loadActivities])

  return (
      <Grid>
          <Grid.Column width='10'>
              {activityStore.loadingInitial && !loadingNext ? (
                  <>
                      <EventListItemPlaceholder />
                      <EventListItemPlaceholder />
                  </>
              ) : (
                      <InfiniteScroll
                          pageStart={0}
                          loadMore={handleGetNext}
                          hasMore={!loadingNext && !!pagination && pagination.currentPage < pagination.totalPages}
                          initialLoad={false}
                      >
                          <EventList />
                      </InfiniteScroll>
                  )}
          </Grid.Column>
          <Grid.Column width='6'>
              <EventFilters />
          </Grid.Column>
          <Grid.Column width={10}>
              <Loader active={loadingNext} />
          </Grid.Column>
      </Grid>
  )
})
