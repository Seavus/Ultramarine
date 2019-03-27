
class Tools {
  static newId = (array) => {
    return Math.max(...(array.map(a => a.id))) + 1;
  }
}

export default Tools