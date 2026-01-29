import { Controller } from "@hotwired/stimulus"

export default class extends Controller {
  static targets = ["fields"]

  addField() {
    const target = this.element.querySelector(`#${this.target}`)
    const fields = this.data.get("fields").replace(/NEW_RECORD/g, new Date().getTime())
    target.insertAdjacentHTML('beforeend', fields)
  }

  removeField(event) {
    event.preventDefault()
    const wrapper = event.target.closest(".nested-fields")
    wrapper.remove()
  }
}