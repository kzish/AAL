import { defineStore } from 'pinia'

export const APPSTORE = defineStore('appstore', {
  //
  state: () => {
    return { 
        count: 0,
        is_logged_in: false, //is the user logged in
        local_user: null, //the user object stored in the local storage
     }
  },
  //
  actions: {
    increment() {
      this.count++
    },
    //user login
    login () {},
    //new user register
    register () {},
    //user logout
    logout () {},
  },
  //
  getters: {
    //get the local user stored in the localstorage
    getUserLocal: () => localStorage.getItem('user') == "" ? null : JSON.parse(localStorage.getItem('user')),
  },


})
