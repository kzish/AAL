<template>
  <div class="tutor-profile-item">
          <div class="row">
            <div class="col-md-2">
              <table>
                <tr>
                  <td>
                    <img v-if="selectedTutorToDisplay.imageUrl!=='' && selectedTutorToDisplay.imageUrl!== null" :src="globals.api_end_point+'/Tutors/GetImage/'+selectedTutorToDisplay.imageUrl" class="rounded float-left tutor-home-img" alt="...">
                    <img v-if="selectedTutorToDisplay.imageUrl=='' || selectedTutorToDisplay.imageUrl==null" src="/assets/img/place-holder-profile-image.png" class="rounded float-left tutor-home-img" alt="...">
                  </td>
                </tr>
                <tr>
                  <td>
                    {{selectedTutorToDisplay.firstname}} {{selectedTutorToDisplay.surname}}
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
                    {{selectedTutorToDisplay.coutryName}}
                    <country-flag :country='selectedTutorToDisplay.coutryIso' size='small'/>
                  </td>
                </tr>
                <tr>
                  <td>
                      <span v-for="language in selectedTutorToDisplay.languages" :key="language">{{language.trim()}}, </span>
                  </td>
                </tr>
                <tr>
                  <td>
                      <span v-for="course in selectedTutorToDisplay.courses" :key="course">{{course.trim().replace(" - " + selectedTutorToDisplay.email, "")}},</span>
                  </td>
                </tr>
                <tr>
                  <td><i><b>{{selectedTutorToDisplay.about}}</b></i></td>
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
</template>

<script>
import {globals} from '@/assets/js/globals.js';
import StarRating from 'vue-star-rating'//https://bestofvue.com/repo/craigh411-vue-star-rating-vuejs-miscellaneous
import CountryFlag from 'vue-country-flag-next';

export default {
  name: 'DisplayTutorInformation',
  components: {
    StarRating,
    CountryFlag,
  },
  props: {
    tutor: Object
  },
  data(){
    return {
      globals: globals,
    }
  },
}
</script>
