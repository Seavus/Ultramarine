class Tools {
  static newId = array => Math.max(...array.map(a => a.id)) + 1
}

export default Tools
