<template>

  <div class="home-banner">
    <center>
        <h4 class="top-title">Online English tutors & teachers for private lessons</h4>
        <p>
          Looking for an online tutor? Adeyemi Academy is the leading online language learning platform in the country. You can choose from 12402+ tutors. Book a lesson with a private tutor today and start learning.
        </p>
    </center>
  </div>

  <div class="top-home-search">
    <center>
      <div class="input-group">
          <input type="text" v-model="search_term" class="form-control top-home-search-text" placeholder="Type Course or topic">
          <div class="input-group-append xs-hide">
            <button type="button" @click="clearSearch" class="btn btn-outline-danger top-home-search-text">
              X<span class="glyphicon glyphicon-align-left" aria-hidden="true"></span>
            </button>
          </div>
          <div class="input-group-append">
            <button @click="fetchTutors" type="button" class="btn btn-outline-primary top-home-search-text">
              Search Course<span class="glyphicon glyphicon-align-left" aria-hidden="true"></span>
            </button>
          </div>
      </div>
    </center>
    <hr />
    <div class="row">
      <div class="col-md-4 col-sm-12 col-xs-12">
        <Multiselect
          class="top-home-search-text"
          placeholder="Select country"
          mode="tags"
          searchable="true"
          label="countryName"
          v-model="selected_countries"
          :options="all_countries"
          ref="multiselect_countries"
        />
        <br />
      </div>
      <div class="col-md-4 col-sm-12 col-xs-12">
        <Multiselect
          class="top-home-search-text"
          placeholder="Select language"
          mode="tags"
          searchable="true"
          label="languageName"
          v-model="selected_languages"
          :options="all_languages"
          ref="multiselect_languages"
        />
        <br/>
      </div>
      <div class="col-md-4 col-sm-12 col-xs-12">
        <input type="text" class="form-control top-home-search-text" placeholder="Select time" data-bs-toggle="offcanvas" data-bs-target="#offcanvasRightSelectTime" readonly />
        <br />
      </div>
    </div>
  </div>
  <div class="tutor-list">
    <div class="row">
      <div class="col-md-12">
          <div class="col-home-left">
            <div class="tutor-profile-item-hover" v-for="tutor in tutors" :key="tutor.aspnetUserId" @click="loadTutorDetails(tutor)" data-bs-toggle="offcanvas" data-bs-target="#offcanvasRightViewSelectedTutor">
              <div class="tutor-profile-item tutor-profile-item-border">
                <div class="row">
                  <div class="col-md-12">
                    <table>
                      <tr>
                        <td>
                          {{tutor.firstname}} {{tutor.surname}} <country-flag :country='tutor.coutryIso' size='small'/>
                        </td>
                      </tr>
                      <tr>
                        <td>
                          <star-rating
                          :increment="1"
                          :rating="4"
                          :max-rating="5"
                          :read-only="true"
                          :show-rating	="false"
                          :star-size="20"
                            />

                        </td>
                      </tr>
                    </table>
                  </div>
                </div>
                <div class="row">
                  <div class="col-md-12">
                    <div class="contact-tutor-icons">
                      <img src="/assets/img/whatsapp_icon.png" class="tutor-contact-icons" />
                      <img src="/assets/img/call_icon.png" class="tutor-contact-icons" />
                      <img src="/assets/img/email_icon.png" class="tutor-contact-icons-email" />
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="col-home-right xs-hide sm-hide">
            <!-- tutor information -->
            <DisplayTutorInformation :selectedTutorToDisplay="selectedTutorToDisplay" :border="true"/> 
          </div>
      </div>
      <div class="row">
        <div class="col-md-12 tutor-profile-item-contianer">
          <div class="tutor-profile-item">
            <v-pagination
                v-model="page"
                :pages="total_pages"
                :range-size="1"
                active-color="#DCEDFF"
                @update:modelValue="updateTutorPaginationHandler"
              />
          </div>
        </div>
      </div>
    </div>
  </div>

  <!-- select time offcanvas -->
  <div class="offcanvas offcanvas-end" tabindex="-1" id="offcanvasRightSelectTime" aria-labelledby="offcanvasRightLabel">
    <div class="offcanvas-header">
      <!-- <h5 id="offcanvasRightLabel">Select Time</h5> -->
      <button type="button" class="btn btn-outline-danger">Clear all</button> Select Availability
      <button type="button" class="btn-close text-reset" data-bs-dismiss="offcanvas" aria-label="Close"></button>
    </div>
    <div class="offcanvas-body">
    
      <div v-for="weekday in days_of_week" :key="weekday">
        <h5>{{weekday}}</h5>
        <div class="row" style="font-size:12px">
          <div class="col-md-4 col-sm-6"  v-for="time_period in all_time_periods" :key="time_period.id">
            <div class="form-check">
              <input class="form-check-input" type="checkbox" value="true" @click="addRemoveTimePeriod('time_period.Id_weekday')">
              <label class="form-check-label">
                  <b>{{time_period.timePeriod}}</b>
                  <br />
                  <p style="color:teal">{{time_period.title}}</p>
              </label>
            </div>
          </div>
        </div>
        <hr />
      </div>

    
    </div>
  </div>

  <!-- view selected tutor for small devices -->
  <div style="display: none!mportant" class="offcanvas offcanvas-end md-hide lg-hide xl-hide xxl-hide" data-bs-backdrop="true" tabindex="-1" id="offcanvasRightViewSelectedTutor" aria-labelledby="offcanvasRightLabel">
    <div class="offcanvas-header">
      &nbsp;
      <button type="button" class="btn-close text-reset" data-bs-dismiss="offcanvas" aria-label="Close"></button>
    </div>
    <div class="offcanvas-body offcanvas-body-no-padding-no-margin">
      <!-- tutor information -->
      <DisplayTutorInformation :selectedTutorToDisplay="selectedTutorToDisplay" :border="false"/> 
    </div>
  </div>

  <br />
  <br />
  <br />
  <loading :active="isLoading" 
          :can-cancel="true" 
          :on-cancel="onCancel"
          :is-full-page="true" />

</template>

<script>
import {globals} from '@/assets/js/globals.js';
import axios from "axios";
import StarRating from 'vue-star-rating'//https://bestofvue.com/repo/craigh411-vue-star-rating-vuejs-miscellaneous
import CountryFlag from 'vue-country-flag-next';
import Loading from 'vue3-loading-overlay';
import 'vue3-loading-overlay/dist/vue3-loading-overlay.css';
import VPagination from "@hennge/vue3-pagination";
import "@hennge/vue3-pagination/dist/vue3-pagination.css";//https://github.com/HENNGE/vue3-pagination
import Multiselect from '@vueform/multiselect';//https://bestofvue.com/repo/vueform-multiselect-vuejs-form-select
import '@vueform/multiselect/themes/default.css';
import DisplayTutorInformation from '@/components/DisplayTutorInformation.vue';
window.$ = window.jQuery = require('jquery');

export default {
  name: 'Home',
  components: {
    StarRating,
    CountryFlag,
    Loading,
    VPagination,
    Multiselect,
    DisplayTutorInformation,
  },
  data(){
    return {
      tutors: null,
      globals: globals,
      search_term: '',
      page: 1,
      isLoading: false,
      items_per_page: 0,
      total_pages: 0,
      all_countries: null,
      selected_countries: null,
      all_languages: null,
      selected_languages: null,
      showTutorModal: false,
      selectedTutorToDisplay:null,
      days_of_week: ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"],
      all_time_periods: null,
      selected_time_periods: null,
    }
  },
  mounted(){
     this.fetchTutors();
     this.fetchCountries();
     this.fetchLanguages();
     this.fetchTimePeriods();
    //  window.$( document ).ready(function() {
    //     alert('ready');
    // });
  },
  methods: {
    loadTutorDetails(tutor) {
      this.selectedTutorToDisplay = tutor;
    },
    updateTutorPaginationHandler(page_number) {
      this.page = Math.trunc(page_number);
      this.fetchTutors();
    },
    clearSearch() {
      this.search_term = '';
    },
    fetchTutors(){
      this.isLoading = true;
      axios.get(globals.api_end_point+"/Tutors/FetchTutors?page=" + this.page + "&search_param=" + this.search_term)
          .then(response => {
            if(response.data.res === "ok") {
              this.tutors = response.data.tutors;
              this.selectedTutorToDisplay = this.tutors[0];
              this.items_per_page = parseInt(response.data.items_per_page);
              var total_pages = parseInt(response.data.total_tutors)/this.items_per_page;
              if(total_pages == 0 || total_pages == 1) {
                this.total_pages = 1;
              } else if(total_pages%2==0) {
                this.total_pages = total_pages;
              } else {
                this.total_pages = total_pages + 1;
              }
            } else {
              alert(response.data.msg);
            }
          })
          .catch(error => console.log(error))
          .finally(() => {
            this.isLoading = false;
          })
    },
    fetchTimePeriods(){
      this.isLoading = true;
      axios.get(globals.api_end_point+"/Tutors/FetchTimePeriods")
          .then(response => {
            if(response.data.res === "ok") {
              this.all_time_periods = response.data.time_periods;
            } else {
              alert(response.data.msg);
            }
          })
          .catch(error => console.log(error))
          .finally(() => {
            this.isLoading = false;
          })
    },
     fetchCountries(){
      this.isLoading = true;
      axios.get(globals.api_end_point+"/Tutors/FetchCountries")
          .then(response => {
            if(response.data.res === "ok") {
              this.all_countries = response.data.countries;
            } else {
              alert(response.data.msg);
            }
          })
          .catch(error => console.log(error))
          .finally(() => {
            this.isLoading = false;
          })
    },
    fetchLanguages(){
      this.isLoading = true;
      axios.get(globals.api_end_point+"/Tutors/FetchLanguages")
          .then(response => {
            if(response.data.res === "ok") {
              this.all_languages = response.data.languages;
            } else {
              alert(response.data.msg);
            }
          })
          .catch(error => console.log(error))
          .finally(() => {
            this.isLoading = false;
          })
    },
  }
}
</script>
