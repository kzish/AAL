import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import './registerServiceWorker'
import { createPinia } from 'pinia'
import Notifications from '@kyvg/vue3-notification'
///https://github.com/kyvg/vue3-notification

const app = createApp(App)
//
app.use(Notifications)
//
app.use(router)
app.use(createPinia())
app.mount("#app")

// createApp(App).use(router).mount('#app')
