import { defineStore } from 'pinia'
import axios from "axios";
import {globals} from '@/assets/js/globals.js';
import { notify } from "@kyvg/vue3-notification";



export const APPSTORE = defineStore('appstore', {

  //
  state: () => {
    return { 
        count: 0,
        is_logged_in: false, //is the user logged in
        local_user: null, //the user object stored in the local storage
        is_loading: false,
     }
  },
  //
  actions: {
    increment() {
      this.count++
    },
    //user login
    userLogin (_email, _password) {

      this.is_loading = true;
      axios.post(globals.api_end_point + '/Auth/CreateToken', { 
        email: _email,
        password: _password,
      }).then(res => {
        if(res.data.res == "ok") {
          let userDetails = {
            email: res.data.email
          };
          localStorage.setItem('user', userDetails);
          this.is_logged_in = true;
        } else if(res.data.res == "err") {
          notify({
            title: "Authorization",
            text: "You have been logged in!",
          });
      }

        this.is_loading = false;
      })
      .catch((err) => {
          console.log(err);
          this.is_loading = false;
          alert("Error Logging in");
      })

    },
    //new user register
    userRegister () {},
    //user logout
    userLogout () {},
  },
  //
  getters: {
    //get the local user stored in the localstorage
    getUserLocal: () => localStorage.getItem('user') == "" ? null : JSON.parse(localStorage.getItem('user')),
  },


})
