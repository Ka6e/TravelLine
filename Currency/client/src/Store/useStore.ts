import { useSyncExternalStore } from "react";

export const useStore = <T>(store: { getSnapshot: () => T; subscribe: (cb: () => void) => () => void }) => {
  return useSyncExternalStore(store.subscribe, store.getSnapshot);
};
