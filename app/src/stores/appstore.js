import { defineStore } from 'pinia'
import axios from "axios";
import {globals} from '@/assets/js/globals.js';
import { notify } from "@kyvg/vue3-notification";
window.$ = window.jQuery = require('jquery');
import router from '../router'



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
    this.is_logged_in = this.getUser() != null;
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
    //new user register, then auto login
    userRegister (_email, _password) {
      this.is_loading = true;
      axios.post(globals.api_end_point + '/Auth/Register', { 
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
          window.$('#register_modal'). modal('hide');
          this.is_logged_in = true;
          this.is_logged_in = true;
        } else if(res.data.res == "err") {
          notify({
            title: "Authorization",
            text: res.data.msg,
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
    //user logout
    userLogout () {
      this.is_logged_in = false;
      this.is_logged_in = false;
      localStorage.removeItem('user');
      router.replace('/')//go home
    },

    getUser() {
      this.is_logged_in = localStorage.getItem('user') != null;
      return localStorage.getItem('user') == null ? null : JSON.parse(localStorage.getItem('user'));
    },
   
  },
  //
  getters: {
    //get the local user stored in the localstorage
    
    
  },


})
