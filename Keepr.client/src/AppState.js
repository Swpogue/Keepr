import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},
   /** @type {import('./models/Profile.js').Profile} */
   profile: {},
  /** @type {import('./models/Profile.js').Profile | null} */
  activeProfile: null,
  
  /** @type {import('./models/Keep.js').Keep []} */
  keeps: [],
  
  /** @type {import('./models/Keep.js').Keep []} */
  myKeeps: [],
  /** @type {import('./models/Keep.js').Keep []} */
  profileKeeps: [],
  /** @type {import('./models/Keep.js').Keep []} */
  accountKeeps: [],
  /** @type {import('./models/Keep.js').Keep []} */
  activeKeep: [],
  /** @type {import('./models/Keep.js').Keep []} */
  activeVaultKeep: [],
  
  /** @type {import('./models/VaultKeep.js').VaultKeep []} */
  vaultKeeps: [],


  /** @type {import('./models/Vault.js').Vault []} */
  vaults: [],
  /** @type {import('./models/Vault.js').Vault []} */
  myVaults: [],
  /** @type {import('./models/Vault.js').Vault | null} */
  activeVault: null,
  /** @type {import('./models/Vault.js').Vault []} */
  profileVaults: []
})
