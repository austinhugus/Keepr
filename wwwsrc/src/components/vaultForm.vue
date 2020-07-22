<template>
    <div class="vaultForm">
        <form class="d-flex justify-content-right" 
        @submit.prevent="createVault">
            <div class="form-group">
                <input type="text" name="name" placeholder="Name..." v-model="newVault.name" required />
            </div class="form-group">
            <div class="form-group">
                <input type="text" name="description" placeholder="Description..." v-model="newVault.description"
                    required />
            </div class="form-group">
            <div class="form-group">
                <input type="text" name="Img" placeholder="Img...(optional)" v-model="newVault.Img" />
            </div class="form-group">
            <button type="submit" class="btn btn-primary">Create Vault</button>
        </form>
    </div>
</template>

<script>
    export default {
        name: "vaultForm",
        data() {
            return {
                newVault: {},
            };
        },
        computed: {
            vaults() {
                return this.$store.state.vaults;
            },
        },
        methods: {
            createVault() {
                this.$store.dispatch("createVault", this.newVault);
            },
        },
        components: {},
    };
</script>

<style scoped></style>