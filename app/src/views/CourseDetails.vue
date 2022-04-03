<template>
<div class="home-banner">
    <center>
        <h4 class="top-title">Online English tutors & teachers for private lessons</h4>
        <p>
          Looking for an online tutor? Adeyemi Academy is the leading online language learning platform in the country. You can choose from 12402+ tutors. Book a lesson with a private tutor today and start learning.
        </p>
    </center>
  </div>

  course details for enrollment
</template>

<style scoped>

</style>

<script>

import { APPSTORE } from '@/stores/appstore'
window.$ = window.jQuery = require('jquery');
import { notify } from "@kyvg/vue3-notification";
import router from "../router";

import {globals} from '@/assets/js/globals.js';
import axios from "axios";
import StarRating from 'vue-star-rating'//https://bestofvue.com/repo/craigh411-vue-star-rating-vuejs-miscellaneous
import CountryFlag from 'vue-country-flag-next';
import Loading from 'vue3-loading-overlay';
import 'vue3-loading-overlay/dist/vue3-loading-overlay.css';
window.$ = window.jQuery = require('jquery');

export default {
  name: 'CourseDetails',

    components:{
      StarRating,
      CountryFlag,
      Loading,
    },
    setup() {
        const appstore = APPSTORE()

        return {
            appstore,
        }
    },
    data() {
    },
    computed: {},
    mounted() {
        //check if user is logged in
        let user = this.appstore.getUser();
        console.log('course details mounted: user', user);
        if(user == null) {
           notify({
                title: "Authorization",
                text: "You Must be logged in",
                position: "top center",
                type: "error"
            });
          router.push("/");
        }

        this.fetchCourseDetails();
    },
     methods: {
        
       fetchCourseDetails() {

       },
        
    },

}
</script>


