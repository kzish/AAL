import { defineStore } from 'pinia'
import axios from "axios";
import {globals} from '@/assets/js/globals.js';
import { notify } from "@kyvg/vue3-notification";
window.$ = window.jQuery = require('jquery');



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
  mounted() {
    // this.is_logged_in = this.getLoggedInUser() == null;
    // console.log('user', this.getLoggedInUser());
    // alert('mounted');
    this.getUser();
  },
  //
  actions: {
    
    //user login
    userLogin (_email, _password) {

      this.is_loading = true;
      axios.post(globals.api_end_point + '/Auth/CreateToken', { 
        email: _email,
        password: _password,
      }).then(res => {
        console.log('res', res);
        if(res.data.res == "ok") {
          let userDetails = {
            email: res.data.email,
            token: res.data.token,
          };
          localStorage.setItem('user', JSON.stringify(userDetails));
          notify({
            title: "Authorization",
            text: "Your logged in",
            type: "success"
          });
          window.$('#login_modal'). modal('hide');
          this.is_logged_in = true;
        } else if(res.data.res == "err") {
          notify({
            title: "Authorization",
            text: "Invalid login credentials",
            type: "warn"
          });
      }

        this.is_loading = false;
      })
      .catch((err) => {
          console.log(err);
          this.is_loading = false;
          notify({
            title: "Error",
            text: "An error occurred",
            type: "error"
          });
      })

    },
    //new user register
    userRegister () {},
    //user logout
    userLogout () {
      this.is_logged_in = false;
      localStorage.removeItem('user');
    },

    getUser() {
      this.is_logged_in = localStorage.getItem('user') != "";
      return localStorage.getItem('user') == "" ? null : JSON.parse(localStorage.getItem('user'));
    },
   
  },
  //
  getters: {
    //get the local user stored in the localstorage
    
    
  },


})
