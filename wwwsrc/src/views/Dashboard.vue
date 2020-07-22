<template>
  <div class="dashboard">
    <h1>WELCOME Austin</h1>
    public {{ publicKeeps }} user {{ userKeeps }}
    <div class="row justify-content-center">
      <vaultForm />
    </div>
  </div>
</template>

<script>
import vaultForm from "@/components/vaultForm.vue";
export default {
  mounted() {},
  computed: {},
  components: {
    vaultForm,
  },
};
</script>
s
<style></style>
