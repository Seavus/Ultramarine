import TaskTypes from './TaskTypes'

export default class LandingZone {
  constructor() {
    this.id = -1
    this.type = TaskTypes.LANDING_ZONE
    this.taskLanded = null
  }
}
