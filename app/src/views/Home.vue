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
          max="2"
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
          max="3"
          ref="multiselect_languages"
        />
        <br/>
      </div>
      <div class="col-md-4 col-sm-12 col-xs-12">
        <input type="text" :value="selectedDays" class="form-control top-home-search-text" placeholder="Select time" data-bs-toggle="offcanvas" data-bs-target="#offcanvasRightSelectTime" readonly />
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
                      <img @click="showTutorWhatsAppLink(tutor)" v-if="tutor.mobileAvailableOnWhatsapp" data-bs-toggle="modal" data-bs-target="#tutor_contact_details_whatsapp" src="/assets/img/whatsapp_icon.png" class="tutor-contact-icons" />
                      <img @click="showTutorMobileNumbers(tutor)" v-if="tutor.mobile != null" data-bs-toggle="modal" data-bs-target="#tutor_contact_details_call" src="/assets/img/call_icon.png" class="tutor-contact-icons" />
                      <img @click="sendTutorEmail(tutor)" data-bs-toggle="modal" data-bs-target="#tutor_contact_details_email" src="/assets/img/email_icon.png" class="tutor-contact-icons-email" />
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
      <button type="button" @click="clearAllSelectedTimePeriods" class="btn btn-outline-danger">Clear all</button> Select Availability
      <button type="button" class="btn-close text-reset" data-bs-dismiss="offcanvas" aria-label="Close"></button>
    </div>
    <div class="offcanvas-body">
    
      <div v-for="weekday in days_of_week" :key="weekday">
        <h5>{{weekday}}</h5>
        <div class="row" style="font-size:12px">
          <div class="col-md-4 col-sm-6" v-for="(time_period, index) in all_time_periods" :key="time_period.id">
            <div class="form-check">
              <input :ref="'chk_timeperiod_'+weekday+'_'+index" :id="'chk_timeperiod_'+weekday+'_'+index" class="form-check-input chk_timeperiods" type="checkbox" value="true" @click="toggleTimePeriod(weekday, time_period.timePeriod)">
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
  <div style="display: none!mportant" class="offcanvas offcanvas-end md-hide lg-hide xl-hide xxl-hide" data-bs-backdrop="false" tabindex="-1" id="offcanvasRightViewSelectedTutor" aria-labelledby="offcanvasRightLabel">
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

  <!-- tutor contact details modal -->
  <div class="modal fade" id="tutor_contact_details_whatsapp" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">Contact Tutor on Whatsapp</h5>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <h6>click the link below to contact the tutor on whatsapp</h6>
          <div ref="tutor_whats_app_link"></div>
        </div>
      </div>
    </div>
  </div>
  <div class="modal fade" id="tutor_contact_details_call" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">Tutor Mobile</h5>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <div ref="tutor_mobile"></div>
          <hr />
          Other numbers
          <div ref="tutor_other_mobile"></div>
        </div>
      </div>
    </div>
  </div>
  <div class="modal fade" id="tutor_contact_details_email" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">Contact Tutor on Email</h5>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <h6>click the link below to contact the tutor on whatsapp</h6>
          <div ref="tutor_whats_app_link1"></div>
        </div>
      </div>
    </div>
  </div>
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
      selected_countries: [],
      all_languages: null,
      selected_languages: [],
      showTutorModal: false,
      selectedTutorToDisplay:null,
      days_of_week: ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"],
      all_time_periods: null,
      selected_timeperiod_sunday:[],
      selected_timeperiod_monday:[],
      selected_timeperiod_tuesday:[],
      selected_timeperiod_wednesday:[],
      selected_timeperiod_thursday:[],
      selected_timeperiod_friday:[],
      selected_timeperiod_saturday:[],
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
  computed: {
    // a computed getter
    selectedDays: function () {
      let selectedDaysCount = 0;
      if(this.selected_timeperiod_sunday.length > 0) selectedDaysCount ++;
      if(this.selected_timeperiod_monday.length > 0) selectedDaysCount ++;
      if(this.selected_timeperiod_tuesday.length > 0) selectedDaysCount ++;
      if(this.selected_timeperiod_wednesday.length > 0) selectedDaysCount ++;
      if(this.selected_timeperiod_thursday.length > 0) selectedDaysCount ++;
      if(this.selected_timeperiod_friday.length > 0) selectedDaysCount ++;
      if(this.selected_timeperiod_saturday.length > 0) selectedDaysCount ++;
      if(selectedDaysCount > 1) {
        return selectedDaysCount + " Days selected";
      } else if(selectedDaysCount == 1) {
        return selectedDaysCount + " Day selected";
      } else {
        return "";
      }
    }
  },
  methods: {
    clearAllSelectedTimePeriods() {

      this.selected_timeperiod_sunday = [];
      this.selected_timeperiod_monday = [];
      this.selected_timeperiod_tuesday = [];
      this.selected_timeperiod_wednesday = [];
      this.selected_timeperiod_thursday = [];
      this.selected_timeperiod_friday = [];
      this.selected_timeperiod_saturday = [];

      var checkboxes = document.getElementsByClassName('chk_timeperiods');
      for(let obj in checkboxes) {
        checkboxes[obj].checked = false;
      }
    },
    toggleTimePeriod(day, timeperiod) {
      let index = 0;
      let found = false;

      if(day == 'Sunday') { 
        for (let element of this.selected_timeperiod_sunday) {
          if(element == timeperiod) {
            this.selected_timeperiod_sunday.splice(index, 1);
            found = true;
            break;
          }
          index ++;
        }
        if( !found ) {
          this.selected_timeperiod_sunday.push(timeperiod);
        }
      }

      if(day == 'Monday') { 
        for (let element of this.selected_timeperiod_monday) {
          if(element == timeperiod) {
            this.selected_timeperiod_monday.splice(index, 1);
            found = true;
            break;
          }
          index ++;
        }
        if( !found ) {
          this.selected_timeperiod_monday.push(timeperiod);
        }
      }

      if(day == 'Tuesday') { 
        for (let element of this.selected_timeperiod_tuesday) {
          if(element == timeperiod) {
            this.selected_timeperiod_tuesday.splice(index, 1);
            found = true;
            break;
          }
          index ++;
        }
        if( !found ) {
          this.selected_timeperiod_tuesday.push(timeperiod);
        }
      }

      if(day == 'Wednesday') { 
        for (let element of this.selected_timeperiod_wednesday) {
          if(element == timeperiod) {
            this.selected_timeperiod_wednesday.splice(index, 1);
            found = true;
            break;
          }
          index ++;
        }
        if( !found ) {
          this.selected_timeperiod_wednesday.push(timeperiod);
        }
      }

      if(day == 'Thursday') { 
        for (let element of this.selected_timeperiod_thursday) {
          if(element == timeperiod) {
            this.selected_timeperiod_thursday.splice(index, 1);
            found = true;
            break;
          }
          index ++;
        }
        if( !found ) {
          this.selected_timeperiod_thursday.push(timeperiod);
        }
      }

      if(day == 'Friday') { 
        for (let element of this.selected_timeperiod_friday) {
          if(element == timeperiod) {
            this.selected_timeperiod_friday.splice(index, 1);
            found = true;
            break;
          }
          index ++;
        }
        if( !found ) {
          this.selected_timeperiod_friday.push(timeperiod);
        }
      }

      if(day == 'Saturday') { 
        for (let element of this.selected_timeperiod_saturday) {
          if(element == timeperiod) {
            this.selected_timeperiod_saturday.splice(index, 1);
            found = true;
            break;
          }
          index ++;
        }
        if( !found ) {
          this.selected_timeperiod_saturday.push(timeperiod);
        }
      }
    },
    showTutorWhatsAppLink(tutor){
      var message = "Hi, I am intrested in your course on Adeyemi Academy ..."
      var link = `https://api.whatsapp.com/send?phone=${tutor.mobile}&source=${tutor.email}&text=${message}`
      this.$refs.tutor_whats_app_link.innerHTML = `<a href='${link}' target='${tutor.email}'>${link}</a>`;
    },
    showTutorMobileNumbers(tutor){
      this.$refs.tutor_mobile.innerHTML = tutor.mobile;
      this.$refs.tutor_other_mobile.innerHTML = tutor.otherMobile;
    },
    sendTutorEmail(tutor){
      var message = "Hi, I am intrested in your course on Adeyemi Academy ..."
      var link = `https://api.whatsapp.com/send?phone=${tutor.mobile}&source=${tutor.email}&text=${message}`
      this.$refs.tutor_whats_app_link.innerHTML = link;
    },
    loadTutorDetails(tutor) {
      this.selectedTutorToDisplay = tutor;
      document.body.style.overflowY = "visible";//stop bropback from preventing the document scrolling
      document.body.style.paddingRight = "0px";
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
      axios.get(globals.api_end_point + "/Tutors/FetchTutors?page=" + this.page
      + "&search_param=" + this.search_term
      + "&selected_timeperiod_sunday=" + this.selected_timeperiod_sunday
      + "&selected_timeperiod_monday=" + this.selected_timeperiod_monday
      + "&selected_timeperiod_tuesday=" + this.selected_timeperiod_tuesday
      + "&selected_timeperiod_wednesday=" + this.selected_timeperiod_wednesday
      + "&selected_timeperiod_thursday=" + this.selected_timeperiod_thursday
      + "&selected_timeperiod_friday=" + this.selected_timeperiod_friday
      + "&selected_timeperiod_saturday=" + this.selected_timeperiod_saturday
      + "&selected_countries=" + this.selected_countries
      + "&selected_languages=" + this.selected_languages
      )
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
