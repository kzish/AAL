<template>
  <div>
    <div class="home-banner">
      <center>
          <h4 class="top-title">Online English tutors & teachers for private lessons</h4>
          <p>
            Looking for an online tutor? Adeyemi Academy is the leading online language learning platform in the country. You can choose from 12402+ tutors. Book a lesson with a private tutor today and start learning.
          </p>
      </center>
    </div>

      <div class="row">
        <div class="col-md-12">
          <div class="top-home-search">
            <center>
              <div class="input-group">
                  <input type="text" v-model="search_term" class="form-control top-home-search-text" placeholder="Type Course or topic">
                  <div class="input-group-append">
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
                <div class="col-md-4">
                  <Multiselect
                  :class="top-home-search-text"
                    placeholder="Select country"
                    mode="tags"
                    searchable="true"
                    label="countryName"
                    v-model="selected_countries"
                    :options="all_countries"
                    ref="multiselect_countries"
                  />
                </div>
                <div class="col-md-4">
                  <Multiselect
                    placeholder="Select language"
                    mode="tags"
                    searchable="true"
                    label="languageName"
                    v-model="selected_languages"
                    :options="all_languages"
                    ref="multiselect_languages"
                  />
                </div>

                <div class="col-md-4">
                  <select class="form-control" placeholder="Select time">
                    <option value="">Select time</option>
                  </select>
                </div>
            </div>
          </div>
        </div>
      </div>
  </div>

  <div class="tutor-list">
    <div class="row">
      <div class="col-md-12 tutor-profile-item-contianer" v-for="tutor in tutors" :key="tutor.aspnetUserId" data-bs-toggle="modal" data-bs-target="#tutor-details-modal">
        <div class="tutor-profile-item tutor-profile-item-border">
          <div class="row">
            <div class="col-md-2">
              <table>
                <tr>
                  <td>
                    <img v-if="tutor.imageUrl!=='' && tutor.imageUrl!== null" :src="globals.api_end_point+'/Tutors/GetImage/'+tutor.imageUrl" class="rounded float-left tutor-home-img" alt="...">
                    <img v-if="tutor.imageUrl=='' || tutor.imageUrl==null" src="/assets/img/place-holder-profile-image.png" class="rounded float-left tutor-home-img" alt="...">
                  </td>
                </tr>
                <tr>
                  <td>
                    {{tutor.firstname}} {{tutor.surname}}
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
            <div class="col-md-10">
              <table>
                <tr>
                  <td>
                    {{tutor.coutryName}}
                    <country-flag :country='tutor.coutryIso' size='small'/>
                  </td>
                </tr>
                <tr>
                  <td>
                      <span v-for="language in tutor.languages" :key="language">{{language.trim()}}, </span>
                  </td>
                </tr>
                <tr>
                  <td>
                      <span v-for="course in tutor.courses" :key="course">{{course.trim().replace(" - " + tutor.email, "")}},</span>
                  </td>
                </tr>
                <tr>
                  <td><i><b>{{(tutor.about == null ? '' : tutor.about).substring(0,100)}}...</b></i></td>
                </tr>
                <tr>
                  <td><a @click="loadTutorDetails(tutor)" href="javascript:void(0);" >View more</a></td>
                </tr>
              </table>
            </div>
          </div>
          <div class="row">
            <div class="col-md-12">
              <div class="contact-tutor-icons">
                whatsapp, email, call
              </div>
            </div>
          </div>
        </div>
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

<div id="tutor-details-modal" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-xl">
      <div class="modal-content">
        <div class="row">
          <div class="col-md-12">
            <DisplayTutorInformation :tutor="selectedTutorToDisplay" v-if="selectedTutorToDisplay"/>
          </div>
        </div>
      </div>
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

import DisplayTutorInformation from '@/components/DisplayTutorInformation.vue'


export default {
  name: 'Home',
  components: {
    StarRating,
    CountryFlag,
    Loading,
    VPagination,
    Multiselect,
    DisplayTutorInformation
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
    }
  },
  mounted(){
     this.fetchTutors();
     this.fetchCountries();
     this.fetchLanguages();
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
